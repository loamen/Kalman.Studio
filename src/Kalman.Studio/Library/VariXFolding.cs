using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor.Document;

namespace Kalman.Studio
{
    /// <summary>
    /// The class to generate the foldings, it implements ICSharpCode.TextEditor.Document.IFoldingStrategy
    /// </summary>
    public class VariXFolding : IFoldingStrategy
    {
        /// <summary>
        /// Generates the foldings for our document.
        /// </summary>
        /// <param name="document">The current document.</param>
        /// <param name="fileName">The filename of the document.</param>
        /// <param name="parseInformation">Extra parse information, not used in this sample.</param>
        /// <returns>A list of FoldMarkers.</returns>
        public List<FoldMarker> GenerateFoldMarkers(IDocument document, string fileName, object parseInformation)
        {
            List<FoldMarker> list = new List<FoldMarker>();

            int start = 0;

            // Create foldmarkers for the whole document, enumerate through every line.
            for (int i = 0; i < document.TotalNumberOfLines; i++)
            {
                // Get the text of current line.
                string text = document.GetText(document.GetLineSegment(i));

                if (text.StartsWith("def")) // Look for method starts
                    start = i;
                if (text.StartsWith("enddef;")) // Look for method endings
                    // Add a new FoldMarker to the list.
                    // document = the current document
                    // start = the start line for the FoldMarker
                    // document.GetLineSegment(start).Length = the ending of the current line = the start column of our foldmarker.
                    // i = The current line = end line of the FoldMarker.
                    // 7 = The end column
                    list.Add(new FoldMarker(document, start, document.GetLineSegment(start).Length, i, 7));
            }

            return list;
        }

    }

}
