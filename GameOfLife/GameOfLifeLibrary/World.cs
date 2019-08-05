using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace GameOfLifeLibrary
{
    public class World : IWorld
    {
        private string InitialWorld { get; set; }
        private int CellCount { get; set; }
        public int[] WorldSize { get; set; }

        public List<Cell> Cells = new List<Cell>();
        
        public void Initialize(string initialWorld, int cellCount, int[] worldSize)
        {
            InitialWorld = initialWorld;
            CellCount = cellCount;
            WorldSize = worldSize;
        }

        public void CellsSetUp()
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
            Cells.Add(InitialWorld[cellStateIndex] == '.' ? new Cell(false, row, col) : new Cell(true, row, col));
        }

        public bool IsAnyCellAlive()
        {
            return Cells.Any(cell => cell.IsAlive);
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
                newCells.Add(new Cell(cell.IsAliveInNewWorld(neighbours), cell.X, cell.Y));
            }

            return newCells;
        }

        private List<Cell> GetNeighbours(Cell mainCell, List<Cell> oldCells)
        {
            var neighbours = new List<Cell>();

            for (var i = -1; i <= 1; i++)
            {
                for (var j = -1; j <= 1; j++)
                {
                    var row = CheckWrap(mainCell.X + i, WorldSize[0]);
                    var col = CheckWrap(mainCell.Y + j, WorldSize[1]);

                    if (row == mainCell.X && col == mainCell.Y) continue;

                    Cell neighbour = new Cell(
                        oldCells.Find(x => x.X.Equals(row) && x.Y.Equals(col)).IsAlive,
                        oldCells.Find(x => x.X.Equals(row) && x.Y.Equals(col)).X,
                        oldCells.Find(x => x.X.Equals(row) && x.Y.Equals(col)).Y);

                    neighbours.Add(neighbour);
                }
            }

            return neighbours;
        }

        private static int CheckWrap(int location, int locationLength)
        {
            if (locationLength - 1 < location) return 0;
            if (0 > location) return locationLength - 1;

            return location;
        }

        public string GetCurrentWorld()
        {
            int colCount = 0;
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var cell in Cells)
            {
                if (colCount == WorldSize[1])
                {
                    colCount = 0;
                    stringBuilder.Append("\n");
                }

                stringBuilder.Append(cell.IsAlive ? " 0 " : " . ");

                colCount++;
            }

            return stringBuilder.ToString();
        }

    }
}