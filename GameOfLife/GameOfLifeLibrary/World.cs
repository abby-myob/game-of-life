using System.Collections.Generic;
using System.Threading;

namespace GameOfLifeLibrary
{
    public class World
    {
        public string InitialWorld { get; } 
        public int[] WorldSize { get; }
        
        public static List<Cell> Cells = new List<Cell>();

        public World(string initialWorld, int[] worldSize)
        {
            InitialWorld = initialWorld;
            WorldSize = worldSize;
            
        }

        // in instantiation set up all the cells
        public static void SetUp()
        {
            Cells.Add(new Cell(true,1,1));
        }
    }
}