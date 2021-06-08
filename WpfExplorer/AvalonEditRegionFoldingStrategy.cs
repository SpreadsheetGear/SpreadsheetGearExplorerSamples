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
            var folds = new List<NewFolding>();
            CreateFoldingsInternal(document, 0, folds);
            return folds;
        }


        private int CreateFoldingsInternal(TextDocument document, int offset, List<NewFolding> folds)
        {
            if (offset >= document.TextLength)
                return offset;

            bool insideRegion = false;
            string regionLabel = null;
            int regionIndexStart = -1;
            while (offset < document.TextLength)
            {
                char c = document.GetCharAt(offset);
                switch (c)
                {
                    case '#':
                        if (!insideRegion)
                        {
                            string marker = "#region";
                            int markerLength = marker.Length;
                            int markerOffsetEnd = offset + markerLength;
                            if (markerOffsetEnd > document.TextLength)
                                return markerOffsetEnd;

                            if (document.Text.Substring(offset, markerLength) == marker)
                            {
                                insideRegion = true;
                                regionIndexStart = offset;

                                // Extract label
                                var line = document.GetLineByOffset(offset);
                                int lineEnd = line.Offset + line.Length;
                                int labelLength = lineEnd - offset;
                                regionLabel = document.GetText(offset, labelLength).Trim();
                                if (regionLabel.Length == 0)
                                    regionLabel = "#region";
                                offset += regionLabel.Length;
                            }
                            else
                                offset++;
                        }
                        else
                        {
                            string marker = "#endregion";
                            int markerLength = marker.Length;
                            int markerOffsetEnd = offset + markerLength;
                            if (markerOffsetEnd > document.TextLength)
                                return markerOffsetEnd;

                            if (document.Text.Substring(offset, markerLength) == "#endregion")
                            {
                                folds.Add(new NewFolding(regionIndexStart, markerOffsetEnd) { Name = regionLabel, DefaultClosed = true });
                                insideRegion = false;
                                regionLabel = null;
                                regionIndexStart = -1;
                                offset += markerLength;
                            }
                            else
                                offset++;
                        }
                        break;
                    default:
                        offset++;
                        break;
                }
            }
            return offset;
        }
    }
}
