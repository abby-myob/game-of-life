using System.Net;
using System.Runtime.CompilerServices;
using GameOfLifeLibrary;

namespace GameOfLife
{
    internal static class Program 
    {
        private static readonly Game Game = new Game();
        private static readonly Io Io = new Io();
        
        private static void Main()
        {
            var (worldSize, cellCount, initialInput) = GetInputForInitialization(Io);
            Game.Start(initialInput, cellCount, worldSize);
            Ticking(); 
        }

        private static void Ticking()
        {
            FileWriter fileWriter = new FileWriter(Constants.FilePathOutput);
            Io.PrintWorld(Game.ReturnCurrentWorld());
            
            while (Game.IsWorldDead() && Io.KeepTicking())
            {
                if (Io.IfSave())
                {
                    string[] worldString = {Game.ReturnCurrentWorld().GetCurrentWorld()};
                    fileWriter.Save(worldString);
                }
                Game.Tick(); 
                Io.PrintWorld(Game.ReturnCurrentWorld());
            }
        }

        private static (int[] worldSize, int cellCount, string initialInput) GetInputForInitialization(Io io)
        {
            int[] worldSize;
            int cellCount;
            string initialInput;
            
            io.DisplayWelcome();
            if ("file" == io.GetInputType())
            {
                var fileReader = new FileReader(Constants.FilePath);
                worldSize = fileReader.GetWorldSize();
                cellCount = worldSize[0] * worldSize[1];
                initialInput = fileReader.GetInitialInput();
            }
            else
            {
                worldSize = io.GetWorldSize();
                cellCount = worldSize[0] * worldSize[1];
                initialInput = io.GetInitialInput(cellCount);
            }
            
            return (worldSize, cellCount, initialInput);
        }
    }
}