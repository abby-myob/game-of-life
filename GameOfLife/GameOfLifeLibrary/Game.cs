
using System.Collections;

namespace GameOfLifeLibrary
{
    public class Game : IGame
    {
        private readonly World _world = new World();
        
        public void Start()
        {
            string initialWorld = "0..0.00...0..00..0...0...0....0...000...0..0.00...0..00....0.0...0....0....00...0..0." +
                                  "0....0..00....0.0...0....0....00...0..0.00...0..0.....0.0...0....0....00.......0.0..." +
                                  "0....0....00...0..0.0....0..00....0....0.0...0....0.....0...0..0.0....0..00....0....0" +
                                  ".0...0....0....00...0..0.0....0..00....0....0.0...0....0....00...0..0.0....0..00....0";
            int cellCount = 340;
            int[] worldSize = new []{20,17};
            
            _world.Initialize(initialWorld, cellCount, worldSize);
            _world.CellsSetUp();  
        }

        public void Start(string initialWorld, int cellCount, int[] worldSize)
        {
            _world.Initialize(initialWorld, cellCount, worldSize);
            _world.CellsSetUp(); 
        }
        
        public void Tick()
        {
            _world.Tick();
        }

        public bool IsWorldDead()
        {
            return _world.IsAnyCellAlive();
        }

        public World ReturnCurrentWorld()
        {
            return _world;
        }
        
        public string Output()
        {
            return _world.GetCurrentWorld();
        }
    }
}