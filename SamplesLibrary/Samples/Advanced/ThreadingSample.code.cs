namespace SamplesLibrary.Samples.Advanced
{
    public class ThreadingSample : ISpreadsheetGearWindowsSample
    {
        public void InitializeSample(IWorkbookView workbookView)
        {
            workbookView.GetLock();
            try
            {
                var cells = workbookView.ActiveWorksheet.Cells;
                cells["A1"].Value = "Thread Status";
                cells["B1"].Value = "Iterations";
                cells["C1"].Value = "Last Count";
                cells["D1"].Value = "Total Count";
                cells["E1"].Value = "Average Count";
                cells["A:E"].Columns.AutoFit();
            }
            finally
            {
                workbookView.ReleaseLock();
            }
        }


        public void AddThread(IWorkbookView workbookView)
        {
            MyBackgroundWorker worker;

            // Get starting row.
            int row = MyBackgroundWorkerCount + 1;

            // Acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get the range for this thread.
                SpreadsheetGear.IRange range = workbookView.ActiveWorksheet.Cells[row, FirstColumnIndex, row, LastColumnIndex];
                range.Select();

                // Create the background worker.
                worker = new MyBackgroundWorker(range);
            }
            finally
            {
                // Release the workbook set lock.
                workbookView.ReleaseLock();
            }

            // Do this work after releasing the lock so that we hold the lock
            // for as little time as possible.
            myBackgroundWorkers.Add(worker);

            // Create a thread.
            System.Threading.Thread thread = new System.Threading.Thread(worker.Run) {
                // Give it a name matching the total added thread count.
                Name = MyBackgroundWorkerCount.ToString(),

                // Make it a background thread so it will die when the
                // application is closed.
                IsBackground = true
            };

            // Start it up.
            thread.Start();
        }

        public void RemoveThread(IWorkbookView workbookView)
        {
            int count = MyBackgroundWorkerCount;
            if (count != 0)
            {
                // Stop the last worker and remove it from the list.
                MyBackgroundWorker worker = myBackgroundWorkers[count - 1];
                myBackgroundWorkers.Remove(worker);
                worker.Stop();

                // Acquire a workbook set lock.
                workbookView.GetLock();
                try
                {
                    // Select the previous worker.
                    workbookView.ActiveWorksheet.Cells[count - 1, FirstColumnIndex, count - 1, LastColumnIndex].Select();
                }
                finally
                {
                    // Release the workbook set lock.
                    workbookView.ReleaseLock();
                }
            }
            else
                throw new System.InvalidOperationException("There are no threads to remove.");
        }

        private int MyBackgroundWorkerCount
        {
            get
            {
                return myBackgroundWorkers.Count;
            }
        }

        private readonly System.Collections.Generic.List<MyBackgroundWorker> myBackgroundWorkers =
            new System.Collections.Generic.List<MyBackgroundWorker>();


        private class MyBackgroundWorker
        {
            // Initialize a worker. Note that we do not pass a WorkbookView to the
            // background worker thread due to the fact that WorkbookView properties
            // and methods should only be accessed on the GUI thread which created them.
            internal MyBackgroundWorker(SpreadsheetGear.IRange range)
            {
                System.Diagnostics.Debug.Assert(range.RowCount == 1 && 
                    range.ColumnCount == (LastColumnIndex - FirstColumnIndex + 1));
                this.range = range;
                stop = false;
                totalCount = 0;

                // Make sure each pseudo-random number generator has unique seed.
                rand = new System.Random(range.Row);

                // Set this to true to use advanced API for better
                // performance or false to use IRange.Value.
                fastWay = true;
            }

            // Do work until stopped.
            internal void Run()
            {
                // Set thread status to Running and create formula.
                SetThreadStatus("Running", true);

                // Cache the advanced cells IValues interface and starting
                // row / column of the range for use later.
                SpreadsheetGear.Advanced.Cells.IValues values = (SpreadsheetGear.Advanced.Cells.IValues)range.Worksheet;
                int row = range.Row;
                int col = range.Column;

                // Loop until Stop() is called.
                while (true)
                {
                    // Must enter a critical section to call Monitor.Wait.
                    lock (this)
                    {
                        if (!stop)
                        {
                            // Wait between zero and 1000 milliseconds (0.0 and 1.0 seconds),
                            // or until Stop() is called.
                            System.Threading.Monitor.Wait(this, rand.Next(0, 1000));
                        }
                        if (stop)
                            break;
                    }

                    // Get some random data - do as much work as we can before getting
                    // the lock so we hold the lock for the shortest possible time.
                    double lastCount = rand.Next(1, 100);
                    totalCount += lastCount;
                    iterations += 1;

                    // Acquire the workbook set lock.
                    //
                    // Note that IWorkbookSet.BeginUpdate / EndUpdate will be faster
                    // in cases where more changes are made for each acquired lock.
                    range.WorkbookSet.GetLock();
                    try
                    {
                        // fastWay is initialized in the constructor. Setting values
                        // with IValues instead of IRange.Value is significantly faster.
                        //
                        // It is important to note that a system with a large number of
                        // background updates to process should have few worker threads 
                        // which do as much work as possible during each GetLock / ReleaseLock,
                        // unlike this sample which has one thread for each event and calls
                        // GetLock / ReleaseLock for each and every event. Handling as many
                        // events as possible within one GetLock / ReleaseLock adds significant
                        // complexity, but should prove to be significantly more scalable
                        // because it will cut down on the number of thread context switches.
                        if (fastWay)
                        {
                            // Place the values the fast way.
                            values.SetNumber(row, col + IterationsColumnIndex, iterations);
                            values.SetNumber(row, col + LastCountColumnIndex, lastCount);
                            values.SetNumber(row, col + TotalCountColumnIndex, totalCount);
                        }
                        else
                        {
                            // Place the values the normal but slow way.
                            range[0, IterationsColumnIndex].Value = iterations;
                            range[0, LastCountColumnIndex].Value = lastCount;
                            range[0, TotalCountColumnIndex].Value = totalCount;
                        }
                    }
                    finally
                    {
                        // Release the workbook set lock.
                        range.WorkbookSet.ReleaseLock();
                    }
                }
                SetThreadStatus("Stopped", false);
            }

            private void SetThreadStatus(string status, bool createAverageFormula)
            {
                // Acquire a workbook set lock.
                range.WorkbookSet.GetLock();
                try
                {
                    SpreadsheetGear.IRange threadStatusCell = range[0, ThreadStatusColumnIndex];
                    threadStatusCell.Formula = "Thread: " + System.Threading.Thread.CurrentThread.Name + " " + status;
                    threadStatusCell.ColumnWidth = 15;
                    if (createAverageFormula)
                        range[0, AverageCountColumnIndex].Formula = string.Format("={0}/{1}",
                            range.WorkbookSet.GetAddress(range.Row, range.Column + TotalCountColumnIndex),
                            range.WorkbookSet.GetAddress(range.Row, range.Column + IterationsColumnIndex));
                }
                finally
                {
                    // Release the workbook set lock.
                    range.WorkbookSet.ReleaseLock();
                }
            }

            // Causes the background thread to stop.
            internal void Stop()
            {
                // Enter critical section.
                lock (this)
                {
                    // Let the background thread know...
                    stop = true;

                    // Wake up the background thread if it is waiting in Monitor.Wait.
                    System.Threading.Monitor.Pulse(this);
                }
            }

            // Some constants for column indexing into the worker range.
            private const int ThreadStatusColumnIndex = 0;
            private const int IterationsColumnIndex = 1;
            private const int LastCountColumnIndex = 2;
            private const int TotalCountColumnIndex = 3;
            private const int AverageCountColumnIndex = 4;

            private readonly SpreadsheetGear.IRange range;  // Stores the range this worker will work on.
            private bool stop;                              // Set to true to stop the worker.
            private bool fastWay;                           // Specifies whether to use IRange.Value or advanced API.
            private double totalCount;                      // Accumulates the total for this worker.
            private double iterations;                      // Accumulates the number of iterations for this worker.
            private readonly System.Random rand;            // For generating pseudo-random data.
        }

        // Some constants for column indexing into ActiveWorksheet.Cells.
        private const int FirstColumnIndex = 0;
        private const int LastColumnIndex = 4;
    }
}
