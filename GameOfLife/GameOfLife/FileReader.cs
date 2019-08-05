using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameOfLife
{
    internal class FileReader
    {
        private List<string> Lines { get; } 

        public FileReader(string filePath)
        {
            Lines = File.ReadAllLines(filePath).ToList();
        }

        public int[] GetWorldSize()
        {
            string line = Lines[0];
            string[] input = line.Split(" ");
            int[] worldSize = {int.Parse(input[0]), int.Parse(input[1])};
            Console.WriteLine(worldSize);
            return worldSize;
        }

        public string GetInitialInput()
        {
            return Lines[1]; 
        }
    }
}