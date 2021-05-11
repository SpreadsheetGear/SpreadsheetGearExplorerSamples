/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace SharedSamples
{
    /// <summary>
    /// Represents a sample that can be run by the user, and holds additional details about the
    /// sample such as a description, its parent category and the source code file(s) for the sample.
    /// </summary>
    public class SampleInfo
    { 
        public static SampleInfo Create<T>(Category category, string name, string description)
        {
            return new SampleInfo(category, typeof(T), name, description);
        }

        protected SampleInfo(Category category, Type sampleType, string name, string description)
        {
            if (sampleType.IsAssignableFrom(typeof(ISample)))
                throw new ArgumentException($"{nameof(sampleType)} must implement {nameof(ISample)}", nameof(sampleType));

            Category = category ?? throw new ArgumentNullException(nameof(category));
            SampleType = sampleType;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? "";
        }

        /// <summary>
        /// The <see cref="Type"/> of the sample, which is used to activate an instance of the sample using 
        /// the <see cref="CreateInstance{T}"/> method.  Should be a type that implements <see cref="ISample"/>,  
        /// which includes <see cref="SharedEngineSample"/>, <see cref="SharedWindowsSample"/> and other types 
        /// that are UI-platform specific (see SGUserControl in WinForms and WPF projects, for instance).
        /// </summary>
        public Type SampleType { get; set; }

        public bool IsSharedEngineSample => typeof(SharedEngineSample).IsAssignableFrom(SampleType);

        public bool IsSharedWindowsSample => typeof(SharedWindowsSample).IsAssignableFrom(SampleType);

        /// <summary>
        /// Name of the sample.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the sample.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The parent <see cref="Category"/> for this sample.
        /// </summary>
        public Category Category { get; set; }

        public string SampleFolderPath => Helpers.GetFullOutputFolderPath(Category.GetFolderPath());

        /// <summary>
        /// Holds any source code file details for this sample.
        /// </summary>
        public List<SourceCodeItem> SourceCodes { get; set; } = new List<SourceCodeItem>();

        /// <summary>
        /// Add a source code file to this sample.
        /// </summary>
        /// <param name="filename">Only provide the file name.  The path will be constructed
        /// based on the Category folder(s) that its in</param>
        public void AddSourceCode(string filename)
        {
            SourceCodes.Add(new SourceCodeItem($@"{SampleFolderPath}\{filename}", Name, Description));
        }

        /// <summary>
        /// Create an instance of this sample.
        /// </summary>
        public T CreateInstance<T>()
        {
            return (T)Activator.CreateInstance(SampleType);
        }

        /// <summary>
        /// After running this sample, an Open XML file can be generated and downloaded.
        /// </summary>
        public bool CanDownloadFile { get; set; } = false;

        /// <summary>
        /// After running this sample, an image of the results can be rendered using SpreadsheetGear.Drawing.Image.
        /// </summary>
        public bool CanRenderImage { get; set; } = false;

        /// <summary>
        /// Specify the A1-reference style range to render.  Specify null to render from A1 to the bottom-right end of the used range.
        /// </summary>
        public string RenderImageRange { get; set; } = null;
    }
}
