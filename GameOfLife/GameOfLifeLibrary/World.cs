using System.Collections.Generic;
using System.Threading;

namespace GameOfLifeLibrary
{
    public class World
    {
        private string InitialWorld { get; }
        public int CellCount { get; }
        private int[] WorldSize { get; }
        
        public readonly List<Cell> Cells = new List<Cell>();

        public World(int[] worldSize, string initialWorld, int cellCount)
        {
            InitialWorld = initialWorld;
            CellCount = cellCount;
            WorldSize = worldSize;
        }
 
        public void SetUp()
        {
            int cellStateIndex = 0;
            for (int row = 0; row < WorldSize[0]; row++)
            {
                for (int col = 0; col < WorldSize[1]; col++)
                {
                    AddCell(row, col, cellStateIndex);
                    cellStateIndex++;
                }
            }
            
        }

        private void AddCell(int row, int col, int cellStateIndex)
        {
            Cells.Add(InitialWorld[cellStateIndex] == '.' ? 
                new Cell(false, row, col) : 
                new Cell(true, row, col));
        }
    }
}