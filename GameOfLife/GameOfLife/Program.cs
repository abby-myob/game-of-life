using GameOfLifeLibrary;

namespace GameOfLife
{
    internal static class Program
    {
        private static void Main()
        {
            var display = new Display();
            Display.DisplayWelcome();
            
            var game = new Game(Display.GetWorldSize(), Display.GetInitialInput(),  display);
            game.Start();
        }
    }
}