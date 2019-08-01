namespace GameOfLifeLibrary
{
    public class Game
    {
        public void Start()
        {
            Display.DisplayWelcome();
            
            var currentWorld = new World(Display.GetInitialInput(), Display.GetWorldSize());
            
            Display.PrintWorld(currentWorld);
            
            
        }
    }
}