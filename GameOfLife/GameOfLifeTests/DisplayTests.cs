using GameOfLifeLibrary;
using Xunit;

namespace GameOfLifeTests
{
    public class DisplayTests
    {
        [Fact]
        public void Should_Print_4_x_4_world_where_everything_is_dead()
        {
            Cell cell = new Cell(true);
 
            Assert.True(cell.IsAlive);
        }
    }
}