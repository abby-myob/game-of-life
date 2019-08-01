using GameOfLifeLibrary;

namespace GameOfLife
{
    static class Program
    {
        static void Main(string[] args)
        {
            Display display = new Display();

            display.DisplayWelcome();
            
            Game game = new Game(display.GetInitialInput(), display.GetWorldSize(), display);

            game.Start();
        }
    }
}