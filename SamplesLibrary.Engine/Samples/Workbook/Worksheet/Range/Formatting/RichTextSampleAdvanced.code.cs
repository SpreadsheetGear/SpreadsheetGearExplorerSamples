// ------------------------------------------------------------
// SpreadsheetGear.Extensions.Rtf
// 
// Copyright (c) 2025 https://www.linkedin.com/in/hideghety/
// Licensed under the MIT License.
// ------------------------------------------------------------
using SpreadsheetGear;
using System;
using System.Collections.Generic;
using System.Linq;
using SpreadsheetGear.Extensions.Rtf;

namespace SamplesLibrary.Engine.Samples.Workbook.Worksheet.Range.Formatting
{
    public class RichTextSampleAdvanced : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
        }

        public void RunSample()
        {
            // Create some local variables to the active worksheet and its cells.
            var worksheet = Workbook.ActiveWorksheet;
            var cells = worksheet.Cells;

            // Get a reference to cell B2.
            var cell = cells["B2"];

            var wasPlainText = cell.HasRichText();

            var baseFont = new SsgFont { Size = 24, Color = Color.FromArgb(255, 0, 0, 128) };
            var richText = new SsgRichText();

            // Example 1: add runs with direct overrides
            richText.AddText("Spreadsheet ", baseFont);
            richText.AddText("Gear ", baseFont, color: Color.FromArgb(255, 233, 14, 14));
            richText.AddText("Engine ", baseFont, isBold: true);
            richText.AddText("for", baseFont, underline: UnderlineStyle.Single);

            // Example 2: clone base font and override
            richText.AddText(" .NET", baseFont.Clone(isItalic: true));

            // Example 3: alter any run later (useful for replacements while keeping formatting)
            richText.Last().Text = " .NET - Example using advanced RichText API";

            cell.SetRichText(richText);

            // Example 4: reading RTF back from a cell
            var isNowRichText = cell.HasRichText();
            var extractedRichText = cell.GetRichText();

            // AutoFit the column.
            cell.EntireColumn.AutoFit();
        }
    }

}

namespace SpreadsheetGear.Extensions.Rtf
{

    /// <summary>
    /// Font wrapper class for easier comparison and manipulation
    /// </summary>
    public class SsgFont
    {
        public string Name { get; set; } = string.Empty;
        public double Size { get; set; }
        public bool Bold { get; set; }
        public bool Italic { get; set; }
        public UnderlineStyle Underline { get; set; } = UnderlineStyle.None;
        public bool Strikethrough { get; set; }
        public Color Color { get; set; } = Color.FromArgb(255, 0, 0, 0);
        public bool Subscript { get; set; }
        public bool Superscript { get; set; }

        public SsgFont()
        {
            Name = "Calibri";
            Size = 11;
            Bold = false;
            Italic = false;
            Underline = UnderlineStyle.None;
            Strikethrough = false;
            Color = Color.FromArgb(255, 0, 0, 0);
            Subscript = false;
            Superscript = false;
        }

        public SsgFont(IFont font)
        {
            Name = font.Name;
            Size = font.Size;
            Bold = font.Bold;
            Italic = font.Italic;
            Underline = font.Underline;
            Strikethrough = font.Strikethrough;
            Color = font.Color;
            Subscript = font.Subscript;
            Superscript = font.Superscript;
        }

        public SsgFont Clone(
            string? fontName = null,
            double? fontSize = null,
            bool? isBold = null,
            bool? isItalic = null,
            Color? color = null,
            UnderlineStyle? underline = null,
            bool? strikethrough = null,
            bool? subscript = null,
            bool? superscript = null)
        {
            return new SsgFont
            {
                Name = fontName ?? Name,
                Size = fontSize ?? Size,
                Bold = isBold ?? Bold,
                Italic = isItalic ?? Italic,
                Color = color ?? Color,
                Underline = underline ?? Underline,
                Strikethrough = strikethrough ?? Strikethrough,
                Subscript = subscript ?? Subscript,
                Superscript = superscript ?? Superscript
            };
        }

        public void ApplyToFont(IFont font)
        {
            font.Name = Name;
            font.Size = Size;
            font.Bold = Bold;
            font.Italic = Italic;
            font.Underline = Underline;
            font.Strikethrough = Strikethrough;
            font.Color = Color;
            font.Subscript = Subscript;
            font.Superscript = Superscript;
        }

        // --- Comparison ---
        public override bool Equals(object? obj)
        {
            if (obj is not SsgFont other) return false;
            return
                Name == other.Name &&
                Math.Abs(Size - other.Size) < 0.01 &&
                Bold == other.Bold &&
                Italic == other.Italic &&
                Underline == other.Underline &&
                Strikethrough == other.Strikethrough &&
                Color.Equals(other.Color) &&
                Subscript == other.Subscript &&
                Superscript == other.Superscript;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                Name,
                Math.Round(Size, 2),
                Bold,
                Italic,
                Underline,
                Strikethrough,
                Color,
                HashCode.Combine(
                    Subscript,
                    Superscript
                )
            );
        }

        public static bool operator ==(SsgFont? left, SsgFont? right)
            => Equals(left, right);

        public static bool operator !=(SsgFont? left, SsgFont? right)
            => !Equals(left, right);
    }

    /// <summary>
    /// Structure similar to other OpenXML based APIs for handling RichText, where each differently formatted part is called a "run" or "part", "portion", ...
    /// </summary>
    public class SsgTextRun
    {
        public string Text { get; set; } = string.Empty;
        public SsgFont Font { get; set; } = new SsgFont();

        public SsgTextRun()
        {
        }

        public SsgTextRun(string text)
        {
            Text = text;
        }

        public SsgTextRun(string text, SsgFont font)
        {
            Text = text;
            Font = font;
        }

        public SsgTextRun Clone()
        {
            return new SsgTextRun
            {
                Text = Text,
                Font = Font.Clone()
            };
        }
    }

    /// <summary>
    /// Single class to hold RTF cell content as a collection of text runs...
    /// </summary>
    public class SsgRichText : List<SsgTextRun>
    {
        public void AddText(string text)
        {
            Add(new SsgTextRun(text));
        }

        /// <summary>
        /// Adds text using a base font, then overrides optional properties.
        /// 
        /// NOTE: Personally, I'd remove the optional parameters and just use the overload that takes a cloned font!
        /// </summary>
        public void AddText(
            string text,
            SsgFont baseFont,
            string? fontName = null,
            double? fontSize = null,
            bool? isBold = null,
            bool? isItalic = null,
            UnderlineStyle? underline = null,
            Color? color = null)
        {
            if (baseFont == null) throw new ArgumentNullException(nameof(baseFont));

            // Clone the base font and override properties if provided
            var font = baseFont.Clone();
            if (fontName != null) font.Name = fontName;
            if (fontSize.HasValue) font.Size = fontSize.Value;
            if (isBold.HasValue) font.Bold = isBold.Value;
            if (isItalic.HasValue) font.Italic = isItalic.Value;
            if (underline.HasValue) font.Underline = underline.Value;
            if (color.HasValue) font.Color = color.Value;

            Add(new SsgTextRun(text, font));
        }

        public string GetPlainText()
        {
            return string.Concat(this.Select(run => run.Text));
        }
    }

    /// <summary>
    /// Extension methods for SpreadsheetGear to handle rich text in cells.
    /// </summary>
    public static class IRangeRtfExtensions
    {
        /// <summary>
        /// Compares two SpreadsheetGear.Ifont for equality...
        /// </summary>
        private static bool HasSameFormatting(IFont font1, IFont font2)
        {
            return
                font1.Name == font2.Name &&
                Math.Abs(font1.Size - font2.Size) < 0.01 &&
                font1.Bold == font2.Bold &&
                font1.Italic == font2.Italic &&
                font1.Underline == font2.Underline &&
                font1.Strikethrough == font2.Strikethrough &&
                font1.Color.Equals(font2.Color) &&
                font1.Subscript == font2.Subscript &&
                font1.Superscript == font2.Superscript;
        }

        /// <summary>
        /// Detects if a cell contains rich text formatting (multiple different styled characters)
        /// </summary>
        public static bool HasRichText(this IRange cell)
        {
            if (cell.CellCount != 1)
                throw new ArgumentException("Cell range must be a single cell.");

            if (cell == null || string.IsNullOrEmpty(cell.Text) || cell.Text.Length <= 1)
                return false;

            try
            {
                // Get the first character's font as baseline
                var firstCharFont = cell.GetCharacters(0, 1).Font;

                for (int i = 1; i < cell.Text.Length; i++)
                {
                    var currentCharFont = cell.GetCharacters(i, 1).Font;
                    if (!HasSameFormatting(firstCharFont, currentCharFont))
                        return true;
                }

                return false;
            }
            catch
            {
                // Return false on any error, assuming it's not a rich text cell
                return false;
            }
        }

        /// <summary>
        /// Converts a cell's rich text into a collection of text runs...
        /// </summary>
        public static SsgRichText GetRichText(this IRange cell)
        {
            if (cell.CellCount != 1)
                throw new ArgumentException("Cell range must be a single cell.");

            var richText = new SsgRichText();

            if (cell == null || string.IsNullOrEmpty(cell.Text))
                return richText;

            try
            {
                string text = cell.Text;
                if (text.Length == 0)
                    return richText;

                var currentRun = new SsgTextRun();
                var firstChar = cell.GetCharacters(0, 1);
                currentRun.Font = new SsgFont(firstChar.Font);
                currentRun.Text = text[0].ToString();

                for (int i = 1; i < text.Length; i++)
                {
                    var currentChar = cell.GetCharacters(i, 1);
                    var newFont = new SsgFont(currentChar.Font);

                    if (currentRun.Font == newFont)
                    {
                        currentRun.Text += text[i];
                    }
                    else
                    {
                        richText.Add(currentRun);
                        currentRun = new SsgTextRun(text[i].ToString(), newFont);
                    }
                }
                richText.Add(currentRun);
            }
            catch
            {
                // Fallback: return a single run with the cell's main font
                richText.Clear();
                var fallbackRun = new SsgTextRun(cell.Text, new SsgFont(cell.Font));
                richText.Add(fallbackRun);
            }

            return richText;
        }

        /// <summary>
        /// Writes rich text back to a cell from the SsgRichText structure
        /// </summary>
        public static void SetRichText(this IRange cell, SsgRichText richText)
        {
            if (cell == null || cell.CellCount != 1)
                throw new ArgumentException("Cell range must be a single cell.");

            if (richText == null || richText.Count == 0)
            {
                cell.Value = string.Empty;
                return;
            }

            try
            {
                string fullText = richText.GetPlainText();
                cell.Value = fullText;

                if (richText.Count == 1)
                {
                    richText[0].Font.ApplyToFont(cell.Font);
                    return;
                }

                int startIndex = 0;
                foreach (var run in richText)
                {
                    if (!string.IsNullOrEmpty(run.Text))
                    {
                        int length = run.Text.Length;
                        var charRange = cell.GetCharacters(startIndex, length);
                        run.Font.ApplyToFont(charRange.Font);
                        startIndex += length;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to set rich text: {ex.Message}", ex);
            }
        }
    }

}
