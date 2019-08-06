using System.IO;

namespace GameOfLife
{
    internal class FileWriter
    {
        private string FilePath { get; } 
        public FileWriter(string filePath)
        {
            FilePath = filePath; 
        }

        public void Save(string[] output)
        {
            File.WriteAllLines(FilePath, output);
        }
    }
}