using System.Collections.Generic;
using System.Globalization;
using GameOfLifeLibrary;
using Xunit;
using Xunit.Sdk;

namespace GameOfLifeTests
{
    public class CellTests
    {
        [Fact]
        public void Should_cell_be_alive_when_constructed()
        {
            var cell = new Cell(true, 1, 1);
            Assert.True(cell.IsAlive);
        }

        [Theory]
        [InlineData(true, 0, false)]
        [InlineData(true, 4, false)]
        [InlineData(true, 2, true)]
        [InlineData(true, 3, true)]
        [InlineData(false, 0, false)]
        [InlineData(false, 4, false)]
        [InlineData(false, 3, true)]
        public void Live_cell_should_die_with_less_than_two_neighbours(bool isAlive, 
            int numberOfAlive, 
            bool expected)
        {
            var cell = new Cell(isAlive, 1, 1);
            var neighbours = MakeNeighbours(numberOfAlive);

            Assert.Equal(expected ,cell.IsAliveInNewWorld(neighbours));
        }

        private List<Cell> MakeNeighbours(int numberOfAlive)
        {
            var neighbours = new List<Cell>();

            for (var j = 0; j < numberOfAlive; j++)
            {
                neighbours.Add(new Cell(true, 1, 1));
            }

            for (var i = 0; i < 8 - numberOfAlive; i++)
            {
                neighbours.Add(new Cell(false, 1, 1));
            }

            return neighbours;
        }
        
        [Theory]
        [InlineData(1,0,1)]
        [InlineData(4,0,4)]
        public void Get_cell_location_for_X(int x, int y, int expected)
        {
            var cell = new Cell(true, x, y);
            Assert.Equal(expected, cell.X);
        }
        
        [Theory]
        [InlineData(1,0,0)]
        [InlineData(4,5,5)]
        public void Get_cell_location_for_Y(int x, int y, int expected)
        {
            var cell = new Cell(true, x, y);
            Assert.Equal(expected, cell.Y);
        }
    }
}