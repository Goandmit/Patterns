using System.Collections.Generic;

namespace Patterns
{
    public static class FileWriterFactory
    {
        public static IFileWriter GetFileWriter(string className, string filePath, string fileName, List<string> content)         
        {
            switch (className)
            {
                case $"{nameof(TxtWriter)}": return new TxtWriter(filePath, fileName, content);
                case $"{nameof(PdfWriter)}": return new PdfWriter(filePath, fileName, content);
                case $"{nameof(WordWriter)}": return new WordWriter(filePath, fileName, content);                
                default: return new TxtWriter();
            }
        }
    }
}
