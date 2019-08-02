using System.Net;
using System.Runtime.InteropServices;

namespace GameOfLifeLibrary
{
    public class Game
    {
        public void Start()
        {
            Display.DisplayWelcome();
            
            var worldSize = Display.GetWorldSize();
            var cellCount = worldSize[0] * worldSize[1];
            
            var world = new World(worldSize, Display.GetInitialInput(cellCount), cellCount);
            world.SetUp();
            Display.PrintWorld(world);

            //while (world.IsAnyCellAlive())
            {
                world.Tick();
                Display.PrintWorld(world);
            } 
             
        }
    }
}