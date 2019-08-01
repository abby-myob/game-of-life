namespace GameOfLifeLibrary
{
    public class Game
    {
        private string WorldSize { get; }
        private string InitialInput { get; }
        public Display Display { get; }

        public Game(string worldSize, string initialInput, Display display)
        {
            WorldSize = worldSize;
            InitialInput = initialInput;
            Display = display;
        }
        
        public void Start()
        {
           
            World currentWorld = new World();
            Display.PrintWorld(currentWorld);
            // create a world with the initial input
            // display the first world
            
            // loop the ticks of the world.
            for (int i = 0; i < 10; i++)
            {
                // update the cells
                // display the world
                
                
                
            }

        }

        public void PrintWorld(World world)
        {
            Display.PrintWorld(world);
        }
        
    }
}