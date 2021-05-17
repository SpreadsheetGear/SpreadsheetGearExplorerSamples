/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using System;
using System.Collections.Generic;

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
    }

    public class SourceCodeItemDTO
    {
        public string FullPath { get; set; }
        public string FileName { get; set; }
        public string SourceCode { get; set; }
        public string SourceCodeHtml { get; set; }
        public string Language { get; set; }
    }
}
