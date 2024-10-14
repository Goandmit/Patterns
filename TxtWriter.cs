using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Patterns
{
    public class TxtWriter : TextFileWriter, IFileWriter
    {
        public TxtWriter(string filePath, string fileName, List<string> content) 
            : base(filePath, fileName, content)
        {
            fileExtension = ".txt";
        }

        public TxtWriter()
        {
            fileExtension = ".txt";           
            content = new List<string> { "" };
        }

        public void WriteFile()
        {           
            filePath = PrepareFilePath();

            using (StreamWriter streamWriter =
                new StreamWriter(filePath, false, Encoding.Unicode))
            {
                foreach (string line in content)
                {
                    streamWriter.WriteLine(line);
                }
            }
        }
    }
}
