using GameOfLifeLibrary;
using Xunit;

namespace GameOfLifeTests
{
    public class TestCellClass
    {
        [Fact]
        public void Should_cell_be_alive_when_constructed()
        {
            Cell cell = new Cell(true);
 
            Assert.True(cell.State);
        }
        
        [Fact]
        public void Cell_state_be_set_to_alive_()
        {
            Cell cell = new Cell(true); 

            cell.State = false;

            Assert.False(cell.State);
        }
        
        
    }
}