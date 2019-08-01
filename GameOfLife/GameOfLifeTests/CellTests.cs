using System.Collections.Generic;
using GameOfLifeLibrary;
using Xunit;

namespace GameOfLifeTests
{
    public class CellTests
    {
        [Fact]
        public void Should_cell_be_alive_when_constructed()
        {
            Cell cell = new Cell(true);

            Assert.True(cell.IsAlive);
        }

        [Fact]
        public void Cell_state_be_set_to_alive_()
        {
            Cell cell = new Cell(true);

            cell.IsAlive = false;

            Assert.False(cell.IsAlive);
        }

        [Theory]
        [InlineData(true, 0, false)]
        [InlineData(true, 4, false)]
        [InlineData(true, 2, true)]
        [InlineData(true, 3, true)]
        [InlineData(false, 0, false)]
        [InlineData(false, 4, false)]
        [InlineData(false, 3, true)]
        public void Live_cell_should_die_with_less_than_two_neighbours(bool isAlive, int numberOfAlive, bool expected)
        {
            Cell cell = new Cell(isAlive);
            var neighbours = MakeNeighbours(numberOfAlive);

            Assert.Equal(expected ,cell.isAliveInNewWorld(neighbours));
        }

        public List<Cell> MakeNeighbours(int numberOfAlive)
        {
            List<Cell> neighbours = new List<Cell>();

            for (int j = 0; j < numberOfAlive; j++)
            {
                neighbours.Add(new Cell(true));
            }

            for (int i = 0; i < 8 - numberOfAlive; i++)
            {
                neighbours.Add(new Cell(false));
            }

            return neighbours;
        }
    }
}