using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace GameOfLifeLibrary
{
    public class Cell
    {
        public bool IsAlive { get; }
        public int Y { get; }
        public int X { get; }

        public Cell(bool isAlive, int x, int y)
        {
            IsAlive = isAlive;
            Y = y;
            X = x;
        }

        public bool IsAliveInNewWorld(List<Cell> neighbours)
        {
            var aliveNeighbours = 0;

            foreach (var cell in neighbours)
            {
                if (cell.IsAlive) aliveNeighbours++;
            }

            if (IsAlive)
            {
                if (aliveNeighbours > 3) return false;
                if (aliveNeighbours < 2 ) return false;
                return true;
            }

            if (aliveNeighbours == 3) return true;

            return false;
        }
    }
}