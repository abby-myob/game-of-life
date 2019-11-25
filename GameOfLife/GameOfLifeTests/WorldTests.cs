using System;
using GameOfLifeLibrary;
using Xunit;

namespace GameOfLifeTests
{
    public class WorldTests
    {
        [Theory]
        [InlineData("00000....", new[]{3,3},9, 9)]
        public void Check_number_of_cells_in_the_world(string initialWorld, int[] worldSize, int cellCount, int expected)
        {
            var world = new World();
            world.Initialize(initialWorld, cellCount, worldSize);
            world.CellsSetUp();

            Assert.Equal(expected,world.Cells.Count);
        }
        
        [Theory]
        [InlineData("00000....", new[]{3,3},9, true)]
        public void Check_the_cell_set_up(string initialWorld, int[] worldSize, int cellCount, bool correct)
        {
            var world = new World();
            world.Initialize(initialWorld, cellCount, worldSize);
            world.CellsSetUp();

            var i = -1; 
            foreach (var cell in world.Cells)
            {
                i++;
                if (initialWorld != null)
                {
                    var state = initialWorld[i];
                    if (state == '0')
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
                }

                correct = false;
                break;
            }

            Assert.True(correct);
        }

        [Theory]
        [InlineData(".........", new[] {3, 3}, 9, false)]
        [InlineData("..0......", new[] {3, 3}, 9, true)]
        public void For_method_checkAlive_Should_all_cells_be_dead_return_false(
            string initialWorld, 
            int[] worldSize, 
            int cellCount, 
            bool isAlive)
        {
            var world = new World();
            world.Initialize(initialWorld, cellCount, worldSize);
            world.CellsSetUp();
            
            Assert.Equal(isAlive,world.IsAnyCellAlive());
        }

        [Theory]
        [InlineData(new[] {3, 3}, 9, "000000000", ".........")]
        [InlineData(new[] {3, 3}, 9, ".........", ".........")]
        [InlineData(new[] {3, 3}, 9, ".....0...", ".........")]
        public void tick_method_should_produce_correct_new_world(int[] worldSize, int cellCount, string currWorldString,
            string newWorldString)
        {
            var newWorld = new World();
            newWorld.Initialize(newWorldString, cellCount, worldSize);
            
            var currentWorld = new World();
            currentWorld.Initialize(currWorldString, cellCount, worldSize);
            
            currentWorld.CellsSetUp();
            newWorld.CellsSetUp();

            currentWorld.Tick();
            Assert.Equal(currentWorld.Cells, newWorld.Cells);
        }
    }
}