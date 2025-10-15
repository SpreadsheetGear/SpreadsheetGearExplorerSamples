/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SamplesLibrary.Engine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebExplorer
{
    public class SampleInfoDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryDTO Category { get; set; }
        public string SampleFolderPath { get; set; }
        public IEnumerable<SourceCodeItemDTO> SourceCodes { get; set; }
        public bool CanDownloadFile { get; set; }
        public bool CanRenderImage { get; set; }
        public string RenderImageRange { get; set; }

        public static SampleInfoDTO ToDTO(SampleInfo sampleInfo) => new () {
            Name = sampleInfo.Name,
            Description = sampleInfo.Description,
            Category = CategoryDTO.ToDTO(sampleInfo.Category),
            SampleFolderPath = sampleInfo.SampleFolderPath,
            SourceCodes = sampleInfo.SourceCodes?.Select(sc => SourceCodeItemDTO.ToDTO(sc)) ?? Enumerable.Empty<SourceCodeItemDTO>(),
            CanDownloadFile = sampleInfo.CanDownloadFile,
            CanRenderImage = sampleInfo.CanRenderImage,
            RenderImageRange = sampleInfo.RenderImageRange
        };
    }

    public class CategoryDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string FolderName { get; set; }
        public int SortIndex { get; set; }
        public bool IsExpanded { get; set; }
        public bool HideNameFromCategorySummary { get; set; }
        public IEnumerable<CategoryDTO> ChildCategories { get; set; }
        public IEnumerable<string> SampleNames { get; set; }

        public static CategoryDTO ToDTO(Category category) => new () {
            Name = category.Name,
            Description = category.Description,
            FolderName = category.FolderName,
            SortIndex = category.SortIndex,
            IsExpanded = category.IsExpanded,
            HideNameFromCategorySummary = category.HideNameFromCategorySummary,
            ChildCategories = category.ChildCategories?.Select(cc => ToDTO(cc)) ?? Enumerable.Empty<CategoryDTO>(),
            SampleNames = category.SampleInfos?.Select(si => si.Name) ?? Enumerable.Empty<string>()
        };
    }

    public class SourceCodeItemDTO
    {
        public string FullPath { get; set; }
        public string FileName { get; set; }
        public string SourceCode { get; set; }
        public string SourceCodeHtml { get; set; }
        public string Language { get; set; }

        public static SourceCodeItemDTO ToDTO(SourceCodeItem item) =>  new () {
            FullPath = item.FullPath,
            FileName = item.FileName,
            SourceCode = item.GetSourceCode(SourceCodeFormat.Plaintext, 3),
            SourceCodeHtml = item.GetSourceCode(SourceCodeFormat.Html, 3),
            Language = item.Language
        };
    }
}
