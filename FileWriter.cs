namespace Patterns
{
    public class FileWriter
    {
        public IFileWriter ConcreteFileWriter { get; set; }

        public FileWriter(IFileWriter concreteFileWriter)
        {
            ConcreteFileWriter = concreteFileWriter;
        }

        public void Write() => ConcreteFileWriter.WriteFile();        
    }
}
