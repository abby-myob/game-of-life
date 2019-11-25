using System.Collections.Generic;

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

            if (!IsAlive) return aliveNeighbours == 3;
            if (aliveNeighbours > 3) return false;
            return aliveNeighbours >= 2;
        }

        public override bool Equals(object obj)
        {
            return obj is Cell other && (X.Equals(other.X) && Y.Equals(other.Y) && IsAlive.Equals(other.IsAlive));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = IsAlive.GetHashCode();
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ X;
                return hashCode;
            }
        }
    }
}