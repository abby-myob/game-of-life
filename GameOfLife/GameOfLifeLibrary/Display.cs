using System;

namespace GameOfLifeLibrary
{
    public class Display
    {
        public void DisplayWelcome()
        {
            Console.WriteLine(Constants.Welcome);
        }
        public string GetWorldSize()
        {
            Console.WriteLine(Constants.DefineWorldSize);

            return null;
        }

        public string GetInitialInput()
        {
            Console.WriteLine(Constants.SetInitialState);

            return null;
        }

        public void PrintWorld(World world)
        {
            //print the currently world
        }
    }
}