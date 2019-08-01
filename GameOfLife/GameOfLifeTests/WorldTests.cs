using GameOfLifeLibrary;
using Xunit;

namespace GameOfLifeTests
{
    public class WorldTests
    {
        [Theory]
        [InlineData("X.X.X.X.X.", new[]{3,3},9, 9)]
        public void Check_number_of_cells_in_the_world(string initialWorld, int[] worldSize, int cellCount, int expected)
        {
            var world = new World(worldSize, initialWorld, cellCount);
            world.SetUp();

            Assert.Equal(expected,world.Cells.Count);
        }
        
        [Theory]
        [InlineData("X.X.X.X.X.", new[]{3,3},9, true)]
        public void Check_dead_cell_at_location_to_be_dead(string initialWorld, int[] worldSize, int cellCount, bool correct)
        {
            var world = new World(worldSize, initialWorld, cellCount);
            world.SetUp();

            var i = -1; 
            foreach (var cell in world.Cells)
            {
                i++;
                char state = initialWorld[i];
                if (state == 'x' || state == 'X')
                {
                    if (cell.IsAlive) continue;
                    correct = false;
                    break;
                }

                if (state == '.')
                {
                    if (!cell.IsAlive) continue;
                    correct = false;
                    break;
                }

                correct = false;
                break;
            }

            Assert.True(correct);
        }
        
        
        // Test that the world is empty
         
        // Test adding a cell to the world
    }
}