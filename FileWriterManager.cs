using System.Collections.Generic;

namespace Patterns
{
    public static class FileWriterManager
    {
        private static IModel<IAnimal> _model = new AnimalModel();

        private static string _filePath = "";
        private static string _fileName = "Animals";
        private static List<string> _content = new List<string>();
        
        private static FileWriter _fileWriter;
        private static IFileWriter _concreateFileWriter;

        private static string Write(string className)
        {
            string status = "Файл сохранен";

            _content = _model.GetAllInTextFormat();

            _concreateFileWriter = FileWriterFactory.GetFileWriter(className, _filePath, _fileName, _content);

            _fileWriter = new FileWriter(_concreateFileWriter);

            _fileWriter.Write();

            return status;
        }

        public static string WriteToTxt() => Write($"{nameof(TxtWriter)}");        

        public static string WriteToPdf() => Write($"{nameof(PdfWriter)}");

        public static string WriteToWord() => Write($"{nameof(WordWriter)}");
    }
}
