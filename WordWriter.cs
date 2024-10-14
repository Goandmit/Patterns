using System.Collections.Generic;
using Xceed.Words.NET;

namespace Patterns
{
    public class WordWriter : TextFileWriter, IFileWriter
    {
        public WordWriter(string filePath, string fileName, List<string> content)
            : base(filePath, fileName, content)
        {
            fileExtension = ".docx";
        }

        public void WriteFile()
        {
            filePath = PrepareFilePath();

            var doc = DocX.Create(fileName);

            foreach (string line in content)
            {
                doc.InsertParagraph($"{line}");
            }

            doc.Save();
        }
    }
}
