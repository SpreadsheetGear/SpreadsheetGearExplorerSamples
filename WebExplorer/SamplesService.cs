/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using Microsoft.AspNetCore.Mvc;
using SamplesLibrary;
using SpreadsheetGear;
using System;
using System.Drawing;
using System.Linq;

namespace WebExplorer
{
    /// <summary>
    /// Simple service that provides the necessary functionality to retrieve samples and categories as well as execute samples.
    /// </summary>
    public class SamplesService
    {
        private readonly Category _categoryRoot;

        public SamplesService()
        {
            // Load all samples (excluding Windows samples since this is a web-based app).
            _categoryRoot = SamplesBuilder.Build(includeWindowsSamples: false);
        }


        /// <summary>
        /// Gets the root <see cref="Category"/>.
        /// </summary>
        public Category GetRoot()
        {
            return _categoryRoot;
        }


        /// <summary>
        /// Return HTML-formatted summary of the provided category.
        /// </summary>
        public string GetCategorySummary(string categoryName)
        {
            Category category = _categoryRoot.GetCategory(categoryName, true);
            if (category != null)
            {
                var markdown = category.GetCategorySummaryMarkdown("<i class='fas fa-folder-open'></i>", "<i class='fas fa-play-circle text-success'></i>");
                var html = Markdig.Markdown.ToHtml(markdown);
                return html;
            }
            else
                return "";
        }


        public SampleInfo FindSample(string sampleName)
        {
            return FindSampleInternal(_categoryRoot, sampleName);
        }


        /// <summary>
        /// All samples run are of type <see cref="ISpreadsheetGearEngineSample"/>, so can be run on their own (no UI 
        /// involved) using <see cref="ISpreadsheetGearEngineSample.RunSample"/>.
        /// </summary>
        /// <param name="sampleName">Name of the sample to run (<see cref="SampleInfo.Name"/>).
        public FileResult RunSampleDownload(string sampleName)
        {
            // Get the sample and run it.
            SampleInfo sampleInfo = GetSampleInfo(sampleName);
            ISpreadsheetGearEngineSample sample = RunSample(sampleInfo);

            // Save resultant workbook to a memory stream.
            var workbookStream = sample.Workbook.SaveToStream(FileFormat.OpenXMLWorkbook);
            workbookStream.Seek(0, System.IO.SeekOrigin.Begin);

            // Ensure we dispose of the workbook set to avoid limits with the free mode.
            sample.Workbook.WorkbookSet.Dispose();

            // Return the workbook stream with the correct MIME / ContentType.
            FileResult fileResult = new FileStreamResult(workbookStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") {
                FileDownloadName = $"SpreadsheetGear-Sample-{sampleName.Replace(" ", "-")}.xlsx"
            };
            return fileResult;
        }


        /// <summary>
        /// All samples run are of type <see cref="ISpreadsheetGearEngineSample"/>, so can be run on their own (no UI 
        /// involved) using <see cref="ISpreadsheetGearEngineSample.RunSample"/>.
        /// </summary>
        /// <param name="sampleName">Name of the sample to run (<see cref="SampleInfo.Name"/>).
        /// <returns></returns>
        public FileResult RunSampleRenderImage(string sampleName)
        {
            // Get the sample and run it.
            SampleInfo sampleInfo = GetSampleInfo(sampleName);
            ISpreadsheetGearEngineSample sample = RunSample(sampleInfo);

            // Setup some local variables to the resultant workbook for convience.
            IWorkbook workbook = sample.Workbook;
            IWorksheet worksheet = workbook.ActiveWorksheet;
            IRange cells = worksheet.Cells;
            IRange renderRange;

            // Use this range to render if it is specified.
            if (sampleInfo.RenderImageRange != null)
            {
                renderRange = worksheet.Cells[sampleInfo.RenderImageRange];
            }
            // Otherwise, use the worksheet's used range (but starting from A1).
            else
            {
                IRange usedRange = sample.Workbook.ActiveWorksheet.UsedRange;
                renderRange = cells[0, 0,
                    usedRange.Row + usedRange.RowCount - 1,
                    usedRange.Column + usedRange.ColumnCount - 1];
            }

            // Create an image class which will render the image of the specified range.
            // NOTE: the SpreadsheetGear.Drawing.Image class is part of the "SpreadsheetGear for Windows" product,
            // and not available in the "SpreadsheetGear Engine for .NET" product.
            SpreadsheetGear.Drawing.Image image = new SpreadsheetGear.Drawing.Image(renderRange)
            {
                // Increase the DPI to provide sharper results in the browser (image will be scaled by 50% to
                // avoid too large of an image).
                Dpi = 192
            };

            // Render a System.Drawing.Bitmap of the range.
            Bitmap bitmap = image.GetBitmap();

            // Save the bitmap to a PNG file.
            var stream = new System.IO.MemoryStream();
            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            stream.Seek(0, System.IO.SeekOrigin.Begin);

            // Ensure we dispose of the workbook set to avoid limits with the free mode.
            sample.Workbook.WorkbookSet.Dispose();

            // Return the image stream with the correct MIME / ContentType.
            FileResult fileResult = new FileStreamResult(stream, "image/png") {
                FileDownloadName = $"SpreadsheetGear-Sample-{sampleName.Replace(" ", "-")}.png"
            };
            return fileResult;
        }


        private SampleInfo GetSampleInfo(string sampleName)
        {
            SampleInfo sampleInfo = FindSample(sampleName);
            if (sampleInfo == null)
                throw new ArgumentException($"Sample '{sampleName}' does not exist");
            return sampleInfo;
        }


        private ISpreadsheetGearEngineSample RunSample(SampleInfo sampleInfo)
        {
            ISpreadsheetGearEngineSample sample = sampleInfo.CreateInstance<ISpreadsheetGearEngineSample>();
            sample.InitializeWorkbook();
            sample.RunSample();

            return sample;
        }


        private SampleInfo FindSampleInternal(Category category, string sampleName)
        {

            SampleInfo sampleInfo = category.SampleInfos.SingleOrDefault(si => si.Name.Equals(sampleName, StringComparison.InvariantCultureIgnoreCase));
            if (sampleInfo != null)
                return sampleInfo;

            foreach (var childCategory in category.ChildCategories)
            {
                sampleInfo = FindSampleInternal(childCategory, sampleName);
                if (sampleInfo != null)
                    return sampleInfo;
            }
            return null;
        }
    }
}
