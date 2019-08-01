using GameOfLifeLibrary;
using Xunit;

namespace GameOfLifeTests
{
    public class DisplayTests
    {
        [Theory]
        [InlineData("20x20", new int[] {20,20})]
        [InlineData("20x200", new int[] {20,200})]
        [InlineData("20x2", new int[] {20,2})]
        [InlineData("2x20", new int[] {2,20})]
        public void Getting_world_size_from_string_input(string input, int[] output)
        {
            Assert.Equal(output,Display.ConvertWorldSize(input));
        }
    }
}