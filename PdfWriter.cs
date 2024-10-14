using Aspose.Pdf;
using System.Collections.Generic;

namespace Patterns
{
    public class PdfWriter : TextFileWriter, IFileWriter
    {
        public PdfWriter(string filePath, string fileName, List<string> content)
            : base(filePath, fileName, content)
        {
            fileExtension = ".pdf";
        }

        public void WriteFile()
        {
            filePath = PrepareFilePath();

            Document document = new Document();

            Page page = document.Pages.Add();

            foreach (string line in content)
            {
                page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment(line));             
            }

            document.Save(filePath);
        }
    }
}
