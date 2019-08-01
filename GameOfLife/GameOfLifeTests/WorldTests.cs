using System.Collections.Generic;
using GameOfLifeLibrary;
using Xunit;

namespace GameOfLifeTests
{
    public class WorldTests
    {
        [Theory]
        [InlineData("X.X.X.X.X.", new[]{3,3}, 9)]
        public void Construct_the_list_of_cells_in_the_world(string initialWorld, int[] worldSize, int expected)
        {
            var world = new World(initialWorld, worldSize);
            World.SetUp();

            Assert.Equal(expected,World.Cells.Count);
        }
        
        
        // Test that the world is empty
         
        // Test adding a cell to the world
    }
}