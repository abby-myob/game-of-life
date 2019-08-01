using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace GameOfLifeLibrary
{
    public class Cell
    {
        public bool IsAlive { get; set; }

        public Cell(bool isAlive)
        {
            IsAlive = isAlive;
        }

        public bool isAliveInNewWorld(List<Cell> neighbours)
        {
            var aliveNeighbours = 0;


            foreach (var cell in neighbours)
            {
                if (cell.IsAlive)
                {
                    aliveNeighbours++;
                }
            }

            if (IsAlive)
            {
                if (aliveNeighbours > 3)
                {
                    return false;
                }

                if (aliveNeighbours < 2 )
                {
                    return false;
                }
                
                return true;
            }

            if (aliveNeighbours == 3)
            {
                return true;
            }


            return false;
        }
    }
}