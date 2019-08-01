using System.Collections.Generic;

namespace GameOfLifeLibrary
{
    public class World
    {
        private string InitialWorld { get; }
        private int CellCount { get; }
        public int[] WorldSize { get; }
        
        public readonly List<Cell> Cells = new List<Cell>();

        public World(int[] worldSize, string initialWorld, int cellCount)
        {
            InitialWorld = initialWorld;
            CellCount = cellCount;
            WorldSize = worldSize;
        }
 
        public void SetUp()
        {
            var cellStateIndex = 0;
            for (var row = 0; row < WorldSize[0]; row++)
            {
                for (var col = 0; col < WorldSize[1]; col++)
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

        public bool IsAnyCellAlive()
        {
            var result = false;
            foreach (var cell in Cells)
            {
                if (cell.IsAlive)
                {
                    return true;
                }
            }

            return result;
        }
    }
}