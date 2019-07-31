using System;

namespace GameOfLifeLibrary
{
    public class Display
    { 
        
        public string GetWorldSize()
        {
            Console.WriteLine(Constants.Welcome);
            Console.WriteLine(Constants.DefineWorldSize);

            return null;
        }

        public string GetInitialInput()
        {
            Console.WriteLine(Constants.SetInitialState);

            return null;
        }
          
    }
}