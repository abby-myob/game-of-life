using System.ComponentModel.DataAnnotations;
using GameOfLifeLibrary;

namespace GameOfLife
{
    internal static class Program 
    {
        private static Game game = new Game();
        private static Io io = new Io();
        
        private static void Main()
        {
            var (worldSize, cellCount, initialInput) = GetInputForInitialization(io);
            game.Start(initialInput, cellCount, worldSize);
            Ticking(); 
        }

        private static void Ticking()
        {
            io.PrintWorld(game.ReturnCurrentWorld());
            while (game.IsWorldDead())
            {
                game.Tick(); 
                io.PrintWorld(game.ReturnCurrentWorld());
            }
        }

        private static (int[] worldSize, int cellCount, string initialInput) GetInputForInitialization(Io io)
        {
            io.DisplayWelcome();
            var worldSize = io.GetWorldSize();
            var cellCount = worldSize[0] * worldSize[1];
            var initialInput = io.GetInitialInput(cellCount);
            return (worldSize, cellCount, initialInput);
        }
    }
}