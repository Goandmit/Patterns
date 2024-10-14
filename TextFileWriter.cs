using System.Collections.Generic;
using System.Linq;

namespace Patterns
{
    public abstract class TextFileWriter
    {
        protected string fileExtension;
        protected string filePath;
        protected string fileName;        
        protected List<string> content;

        public TextFileWriter(string filePath, string fileName, List<string> content)
        {            
            this.filePath = filePath;
            this.fileName = fileName;            
            this.content = content;
        }

        public TextFileWriter() { }

        protected string PrepareFileName()
        {
            if (fileName.Length == 0)
            {
                fileName = "TextFile";
            }

            fileName = $"{fileName}{fileExtension}";

            return fileName;
        }

        protected string PrepareFilePath()
        {
            fileName = PrepareFileName();

            if (filePath.Length != 0)
            {
                filePath = filePath.Trim();

                char lastSymbol = filePath.Last();

                if (lastSymbol != '/')
                {
                    filePath = $"{filePath}/";
                }
            }

            filePath = $"{filePath}{fileName}";

            return filePath;
        }        
    }
}
