using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace GameOfLifeLibrary
{
    public class World
    {
        private string InitialWorld { get; }
        private int CellCount { get; }
        public int[] WorldSize { get; }
        
        public List<Cell> Cells = new List<Cell>();

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
            foreach (var cell in Cells)
            {
                if (cell.IsAlive)
                {
                    return true;
                }
            }
            return false;
        }

        public void Tick()
        {
            var cells = Cells;
            Cells = UpdateCells(cells);
        }

        private List<Cell> UpdateCells(List<Cell> oldCells)
        {
            var newCells = new List<Cell>();
            
            foreach (var cell in oldCells)
            {
                var neighbours = GetNeighbours(cell, oldCells);
                newCells.Add(new Cell(true/*cell.IsAliveInNewWorld(neighbours)*/,cell.X, cell.Y));
            }

            return newCells;
        }

        private List<Cell> GetNeighbours(Cell mainCell, List<Cell> oldCells)
        {
            List<Cell> neighbours = oldCells;

            for (var i = -1; i <= 1; i++)
            {
                for (var j = -1; j <= 1; j++)
                {
                    var row = CheckWrap(mainCell.X + i, WorldSize[0]);
                    var col = CheckWrap(mainCell.Y + j, WorldSize[1]);

                    var neighbour = oldCells.Find(x => x.X.Equals(row) && x.Y.Equals(col));
                    
                    neighbours.Add(neighbour);
                }
            }

            return neighbours;
        }

        public static int CheckWrap(int location, int rowSize)
        {
            if (rowSize - 1 < location)
            {
                location = 0;
            } else if (rowSize - 1 > location)
            {
                location = rowSize - 1;
            }

            return location;
        }
        
    }
}