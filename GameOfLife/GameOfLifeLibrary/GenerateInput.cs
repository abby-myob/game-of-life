using System.Collections.Generic;
using System.Linq;

namespace GameOfLifeLibrary
{
    public class GenerateInput
    {
        private List<string> Lines { get; } 
        
        public GenerateInput(IEnumerable<string> input)
        {
            Lines = input.ToList();
        }
        
        public int[] GetWorldSize()
        {
            var line = Lines[0];
            var input = line.Split(" ");
            int[] worldSize = {int.Parse(input[0]), int.Parse(input[1])};
            return worldSize;
        }

        public string GetInitialInput()
        {
            return Lines[1];
        }
        
    }
}