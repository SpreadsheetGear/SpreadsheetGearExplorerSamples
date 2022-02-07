/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace SamplesLibrary
{
    /// <summary>
    /// Holds a collection of samples and sub-categories.
    /// </summary>
    public class Category
    {
        public static Category CreateRoot()
        {
            return new Category();
        }

        private Category()
        {
            Name = "[ROOT]";
            FolderName = null;
        }

        private Category(string name, Category parent, string folderName, string description, int sortIndex, bool isExpanded)
        {
            Name = name;
            Parent = parent;
            FolderName = folderName;
            Description = description;
            SortIndex = sortIndex;
            IsExpanded = isExpanded;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Category Parent { get; set; }
        public string FolderName { get; set; }
        public int SortIndex { get; set; }
        public bool IsExpanded { get; set; }
        public bool IsRoot => Name == "[ROOT]";

        /// <summary>
        /// When displayed as a summary, normally the Name of the Category will included at the top of the bullet item.  Set this to false to hide this name.  Primarily used for the topmost "SpreadsheetGear Explorer" category (not needed on Root, as this should not be displayed to begin with).
        /// </summary>
        public bool HideNameFromCategorySummary { get; set; }

        private readonly List<Category> _childCategories  = new List<Category>();
        public IEnumerable<Category> ChildCategories => _childCategories.OrderBy(c => c.SortIndex);
        public List<SampleInfo> SampleInfos { get; set; } = new List<SampleInfo>();


        /// <summary>
        /// Add a sub-category to this category.
        /// </summary>
        /// <param name="name">Name displayed for Category</param>
        /// <param name="folderName">Pass in null or empty string to indicate this Category has no corresponding folder.</param>
        /// <param name="description">Description can include HTML markup.</param>
        public Category AddCategory(string name, string folderName, string description, int? manualSortIndex = null, bool isExpanded = true)
        {
            if (!manualSortIndex.HasValue)
                manualSortIndex = ChildCategories.Select(c => c.SortIndex).DefaultIfEmpty().Max() + 1;
            var cat = new Category(name, this, folderName, description, manualSortIndex.Value, isExpanded);
            _childCategories.Add(cat);
            return cat;
        }


        /// <summary>
        /// Returns a <see cref="Category"/> based on its name.
        /// </summary>
        public Category GetCategory(string categoryName, bool searchAllChildCategories = false)
        {
            if (!searchAllChildCategories)
                return ChildCategories.SingleOrDefault(c => c.Name == categoryName);
            else
                return FindCategory(this, categoryName);
        }

        private Category FindCategory(Category currentCategory, string categoryName)
        {
            foreach (var childCategory in currentCategory.ChildCategories)
            {
                if (categoryName.Equals(childCategory.Name, System.StringComparison.InvariantCultureIgnoreCase))
                {
                    return childCategory;
                }
                else
                {
                    Category foundCategory = FindCategory(childCategory, categoryName);
                    if (foundCategory != null)
                        return foundCategory;
                }
            }
            return null;
        }


        public IEnumerable<object> CategoriesAndSampleInfos
        {
            get
            {
                foreach (var sampleInfo in SampleInfos)
                    yield return sampleInfo;
                foreach (var category in ChildCategories)
                    yield return category;
            }
        }


        /// <summary>
        /// Add a sample to this category.
        /// </summary>
        /// <param name="usesWorkbookView">Indicates whether the execution of this sample depends on the presence of a WorkbookView control. This 
        /// information can be used by the samples app UI to display different icons representing the sample.</param>
        public SampleInfo AddSample<T>(string name, string description, bool usesWorkbookView) where T : ISample
        {
            var sampleInfo = SampleInfo.Create<T>(this, name, description, usesWorkbookView);
            SampleInfos.Add(sampleInfo);
            return sampleInfo;
        }


        /// <summary>
        /// Constructs and returns a path (relative to the executing directory) where any file
        /// required for the execution of samples within this category can be found.
        /// </summary>
        /// <returns></returns>
        public string GetFolderPath()
        {
            var pathList = GetFolderPathInternal(new List<string>());
            return string.Join(@"\", pathList);
        }


        private List<string> GetFolderPathInternal(List<string> currentPath)
        {
            if (!string.IsNullOrEmpty(FolderName))
                currentPath.Insert(0, FolderName);
            if (Parent != null)
                Parent.GetFolderPathInternal(currentPath);
            return currentPath;
        }


        /// <summary>
        /// Construct a summary of this category and all contained samples and sub-categories.
        /// </summary>
        /// <param name="renderFullWebPage">Specifying true will return a fully-contained HTML web page, &lt;html&gt; tag and all, will be included with the summary.  Specifying false will return just a &lt;ul&gt; tag containing the summary for the category, sub-categories, samples, etc.</param>
        public string GetCategorySummaryHtml(bool renderFullWebPage = true)
        {
            string html = $"<ul class='fa-ul'>{GetCategorySummaryHtmlInternal(this)}</ul>";
            if (!this.Parent.IsRoot)
                html = "<h2>Category and Sample Descriptions</h2>" + html;
            if (renderFullWebPage)
            {
                var htmlTemplate = System.IO.File.ReadAllText(Helpers.GetFullOutputFolderPath(@"Files\SummaryTemplate.html"));
                html = htmlTemplate.Replace("[[BODY]]", html);
            }
            return html;
        }


        public string GetCategorySummaryPlaintext()
        {
            var plaintext = GetCategorySummaryPlaintextInternal(this, 0);
            if (!this.Parent.IsRoot)
                plaintext = "Category and Sample Descriptions\r\n\r\n" + plaintext;
            return plaintext;
        }


        public string GetCategorySummaryMarkdown(string categoryIcon = "", string sampleIcon = "")
        {
            var markdown = GetCategorySummaryMarkdownInternal(this, 0, categoryIcon, sampleIcon);
            if (!this.Parent.IsRoot)
                markdown = "## Category and Sample Descriptions\r\n" + markdown;

            return markdown;
        }


        private string GetCategorySummaryHtmlInternal(Category currentCategory)
        {
            var html = "";
            html += $"<li class='folder'><span class='fa-li'><i class='fas fa-folder-open'></i></span>";
            if (!HideNameFromCategorySummary)
                html += $"  <b>{currentCategory.Name}</b>";
            if (!string.IsNullOrWhiteSpace(currentCategory.Description))
                html += $"{(!HideNameFromCategorySummary ? " - " : "")}{currentCategory.Description}";
            if (currentCategory.ChildCategories.Any())
            {
                html += $"  <ul class='fa-ul'>";
                foreach (var childCategory in currentCategory.ChildCategories)
                {
                    html += childCategory.GetCategorySummaryHtmlInternal(childCategory);
                }
                html += $"  </ul>";
            }
            if (currentCategory.SampleInfos.Count > 0)
            {
                html += $"  <ul class='fa-ul'>";
                foreach (var sample in currentCategory.SampleInfos)
                {
                    html += $"<li class='sample'><span class='fa-li text-success'><i class='fas fa-play-circle'></i></span> <b>{sample.Name}</b> - {sample.Description}</li>";
                }
                html += $"  </ul>";
            }
            return html;
        }


        private string GetCategorySummaryPlaintextInternal(Category currentCategory, int numIndents)
        {
            var indents = new string(' ', numIndents * 2);
            var text = "";
            if (!HideNameFromCategorySummary)
                text += $"{indents}- [Category - {currentCategory.Name}]";
            if (!string.IsNullOrWhiteSpace(currentCategory.Description))
            {
                var desc = currentCategory.Description;
                // Level beyond Root is the Explorer summary, which is formatted using HTML and needs to be stripped out.
                if (currentCategory.Parent.IsRoot)
                {
                    var doc = new HtmlDocument();
                    doc.LoadHtml(desc);
                    desc = doc.DocumentNode.InnerText;
                }
                text += $"{(!HideNameFromCategorySummary ? " - " : "")}{desc}";
            }
            text += "\r\n";
            if (currentCategory.ChildCategories.Any())
            {
                foreach (var childCategory in currentCategory.ChildCategories)
                {
                    text += childCategory.GetCategorySummaryPlaintextInternal(childCategory, numIndents + 1);
                }
            }
            if (currentCategory.SampleInfos.Count > 0)
            {
                foreach (var sample in currentCategory.SampleInfos)
                {
                    text += $"{indents}  - [Sample - {sample.Name}] - {sample.Description}\r\n";
                }
            }
            return text;
        }


        private string GetCategorySummaryMarkdownInternal(Category currentCategory, int depth, string categoryIcon, string sampleIcon)
        {
            var text = "";
            if (currentCategory.Parent.IsRoot)
                depth--;

            string tabs = "";
            if (depth > 0)
                tabs = new string('\t', depth);

            if (!HideNameFromCategorySummary)
                text += $"{tabs}*   **{categoryIcon} {currentCategory.Name}**";
            if (!string.IsNullOrWhiteSpace(currentCategory.Description))
            {
                text += $"{(!HideNameFromCategorySummary ? " - " : "")}{currentCategory.Description}";
            }
            text += "\r\n";
            if (currentCategory.SampleInfos.Count > 0)
            {
                foreach (var sample in currentCategory.SampleInfos)
                {
                    text += $"{tabs}\t*   **{sampleIcon} {sample.Name}** - {sample.Description}\r\n"; // Play Icon: 
                }
            }
            if (currentCategory.ChildCategories.Any())
            {
                foreach (var childCategory in currentCategory.ChildCategories)
                {
                    text += childCategory.GetCategorySummaryMarkdownInternal(childCategory, depth + 1, categoryIcon, sampleIcon);
                }
            }
            return text;
        }


        public override string ToString()
        {
            return Name;
        }
    }
}
