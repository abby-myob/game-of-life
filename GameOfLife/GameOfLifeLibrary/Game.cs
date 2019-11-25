
using System.Collections;

namespace GameOfLifeLibrary
{
    public class Game : IGame
    {
        public readonly World World = new World();
        
        public void Start()
        {
            string initialWorld = "0..0.00...0..00..0...0...0....0...000...0..0.00...0..00....0.0...0....0....00...0..0." +
                                  "0....0..00....0.0...0....0....00...0..0.00...0..0.....0.0...0....0....00.......0.0..." +
                                  "0....0....00...0..0.0....0..00....0....0.0...0....0.....0...0..0.0....0..00....0....0" +
                                  ".0...0....0....00...0..0.0....0..00....0....0.0...0....0....00...0..0.0....0..00....0";
            int cellCount = 340;
            int[] worldSize = new []{20,17};
            
            World.Initialize(initialWorld, cellCount, worldSize);
            World.CellsSetUp();  
        }

        public void Start(string initialWorld, int cellCount, int[] worldSize)
        {
            World.Initialize(initialWorld, cellCount, worldSize);
            World.CellsSetUp(); 
        }
        
        public void Tick()
        {
            World.Tick();
        }

        public bool IsWorldDead()
        {
            return World.IsAnyCellAlive();
        }
    }
}