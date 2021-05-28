/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SharedSamples;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace WPFExplorer
{
    /// <summary>
    /// The base class derived from UserControl used for all WPF samples.  Includes an SGDisposalManager to help manage proper disposal 
    /// of workbook sets and WorkbookViews that are used by the samples (proper disposal is needed in order to avoid issues with 
    /// the "free" mode of the products that has row / column / worksheet / workbook limits).
    /// </summary>
    public abstract class SGUserControl : UserControl, ISample, IDisposable
    {
        public SGDisposalManager DisposalManager { get; private set; } = new SGDisposalManager();

        public void Dispose() => Dispose(true);

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                DisposalManager.Dispose();
            }
        }

        public override void EndInit()
        {
            base.EndInit();
            WpfWorkbookView workbookView = this.FindName("workbookView") as WpfWorkbookView;
            if (workbookView != null)
            {
                // After initialization call DisposalManager.RegisterWorkbookViews
                DisposalManager.RegisterWorkbookViews(workbookView);
                // After initialization some samples must call DisposalManager.ResetWorkbookView
                switch (this.GetType().Name)
                {
                    case "ActiveTabChangedSample":
                    case "ShapeSelectionChangedSample":
                    case "DisplayReferenceSample":
                    case "AdvancedPrintingSample":
                    case "BasicPrintingSample":
                    case "PageBreaksSample":
                    case "PageSetupSample":
                        DisposalManager.ResetWorkbookView(workbookView, false);
                        break;
                    default:
                        break;
                }
                // Add event handler for Button events where DisposalManager.ResetWorkbookView must be called
                switch (this.GetType().Name)
                {
                    case "PerformanceSample":
                        ResetWorkbookViewOnButtonEvent("buttonRunSample");
                        break;
                    case "AmortizationCalculatorSample":
                        ResetWorkbookViewOnButtonEvent("buttonCalculate");
                        break;
                    case "WorkbookConsolidationSample":
                        ResetWorkbookViewOnButtonEvent("radioButton1");
                        ResetWorkbookViewOnButtonEvent("radioButton2");
                        ResetWorkbookViewOnButtonEvent("radioButton3");
                        break;
                    case "ActiveWorkbookSample":
                        ResetWorkbookViewOnButtonEvent("buttonNewWorkbook");
                        ResetWorkbookViewOnButtonEvent("buttonLoadDisk");
                        ResetWorkbookViewOnButtonEvent("buttonLoadUriASP");
                        ResetWorkbookViewOnButtonEvent("buttonLoadUriASP");
                        break;
                    case "ActiveWorksheetSample":
                        ResetWorkbookViewOnButtonEvent("buttonRunSample", true);
                        break;
                    default:
                        break;
                }
            }
        }

        private void ResetWorkbookViewOnButtonEvent(string buttonName, bool includeInitialWorkbook = false)
        {
            var button = this.FindName(buttonName);
            if (button != null)
            {
                WpfWorkbookView workbookView = this.FindName("workbookView") as WpfWorkbookView;
                if (workbookView != null)
                {
                    if (button is Button)
                    {
                        ((Button)button).Click += new RoutedEventHandler(delegate (Object o, RoutedEventArgs a)
                        {
                            DisposalManager.ResetWorkbookView(workbookView, includeInitialWorkbook);
                        });
                    }
                    else if (button is RadioButton)
                    {
                        ((RadioButton)button).Checked += new RoutedEventHandler(delegate (Object o, RoutedEventArgs a)
                        {
                            DisposalManager.ResetWorkbookView(workbookView, includeInitialWorkbook);
                        });
                    }
                }
            }
        }

        public Guid Id { get; } = Guid.NewGuid();
    }
}
