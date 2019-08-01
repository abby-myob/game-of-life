namespace GameOfLifeLibrary
{
    public class Game
    {
        public void Start()
        {
            Display.DisplayWelcome();
            
            var worldSize = Display.GetWorldSize();
            var cellCount = worldSize[0] * worldSize[1];
            
            var currentWorld = new World(worldSize, Display.GetInitialInput(cellCount), cellCount);
            currentWorld.SetUp();
            Display.PrintWorld(currentWorld);
            
            
        }
    }
}