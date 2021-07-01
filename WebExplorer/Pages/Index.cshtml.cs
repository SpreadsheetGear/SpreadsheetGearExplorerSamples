/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SamplesLibrary;
using System;

namespace WebExplorer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SamplesService _samplesService;
        private readonly IMapper _mapper;

        public IndexModel(SamplesService samplesService, IMapper mapper)
        {
            _samplesService = samplesService;
            _mapper = mapper;
        }

        /// <summary>
        /// Used to populate the Tree View containing samples and categories.
        /// </summary>
        public CategoryDTO CategoryRoot { get; set; }


        public void OnGet()
        {
            var root = _samplesService.GetRoot();
            CategoryRoot = _mapper.Map<CategoryDTO>(root);
        }


        /// <summary>
        /// Retrieves details about the specified sample.
        /// </summary>
        public IActionResult OnGetLoadSample(string sampleName)
        {
            SampleInfo sampleInfo = _samplesService.FindSample(sampleName);
            if (sampleInfo == null)
                return BadRequest($"Sample '{sampleName}' does not exist");

            SampleInfoDTO sampleInfoDto = _mapper.Map<SampleInfoDTO>(sampleInfo);
            return new JsonResult(sampleInfoDto);
        }


        /// <summary>
        /// Runs the sample and either returns a resulting file or renders an image of the results.
        /// </summary>
        /// <param name="sampleName">The name of the sample (<see cref="SampleInfo.Name"/>).
        public IActionResult OnGetRunSample(string sampleName, RunSampleType runSampletype)
        {
            try
            {
                FileResult fileResult;
                if (runSampletype == RunSampleType.RenderImage)
                    fileResult = _samplesService.RunSampleRenderImage(sampleName);
                else if (runSampletype == RunSampleType.DownloadFile)
                    fileResult = _samplesService.RunSampleDownload(sampleName);
                else
                    throw new Exception("Invalid RunSampleType was provided.");

                return fileResult;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Gets the HTML summary contents of the provided category.
        /// </summary>
        public IActionResult OnGetCategorySummary(string categoryName)
        {
            string summary = _samplesService.GetCategorySummary(categoryName);
            return Content(summary);
        }
    }


    public enum RunSampleType
    {
        RenderImage,
        DownloadFile
    }
}
