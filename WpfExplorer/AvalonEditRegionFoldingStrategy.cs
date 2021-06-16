/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using System;
using System.Collections.Generic;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Folding;

namespace WPFExplorer
{
    /// <summary>
    /// Helper for AvalonEdit control to locate and fold instances of #region / #endregion.
    /// </summary>
    public class AvalonEditRegionFoldingStrategy
    {
        public IEnumerable<NewFolding> CreateFoldings(TextDocument document)
        {
            List<NewFolding> newFoldings = new List<NewFolding>();
            Stack<RegionInfo> startOffsets = new Stack<RegionInfo>();
            int offset = 0;
            while (offset < document.TextLength)
            {
                char c = document.GetCharAt(offset);
                if (c == '#')
                {
                    if (document.Text.Substring(offset, "#region".Length) == "#region")
                    {
                        // Extract label from region
                        var line = document.GetLineByOffset(offset);
                        int lineEnd = line.Offset + line.Length;
                        int labelLength = lineEnd - offset;
                        string regionLabel = document.GetText(offset, labelLength).Trim();
                        if (regionLabel.Length == 0)
                            regionLabel = "#region";

                        startOffsets.Push(new RegionInfo(offset, regionLabel));
                        offset = lineEnd;
                    }
                    else if (document.Text.Substring(offset, "#endregion".Length) == "#endregion")
                    {
                        int endOffset = offset + "#endregion".Length;
                        var lastRegion = startOffsets.Pop();
                        newFoldings.Add(new NewFolding()
                        {
                            StartOffset = lastRegion.StartOffset,
                            EndOffset = endOffset,
                            Name = lastRegion.Label,
                            DefaultClosed = true
                        });
                        offset = endOffset;
                    }
                    else
                        offset++;
                }
                else
                    offset++;
            }
            newFoldings.Sort((a, b) => a.StartOffset.CompareTo(b.StartOffset));
            return newFoldings;
        }

        private class RegionInfo
        {
            public RegionInfo(int startOffset, string label)
            {
                StartOffset = startOffset;
                Label = label;
            }
            public int StartOffset { get; set; }
            public string Label { get; set; }
        }
    }
}
