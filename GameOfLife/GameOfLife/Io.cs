using System;
using System.ComponentModel.DataAnnotations;
using GameOfLifeLibrary;

namespace GameOfLife
{
    public class Io
    {
        public void DisplayWelcome()
        {
            Console.WriteLine(Constants.Welcome);
        }

        public int[] GetWorldSize()
        {
            string response;
            Console.WriteLine(Constants.DefineWorldSize);
            while (true)
            {
                response = Console.ReadLine();
                if (WorldSizeValidation.IsValidWorldSize(response)) break;

                Console.WriteLine(Constants.WorldSizeInputError);
            }

            return WorldSizeValidation.ConvertWorldSizeStringToInts(response);
        }
        
        public string GetInitialInput(int cellCount)
        {
            Console.WriteLine(Constants.SetInitialState);
            string response;

            while (true)
            {
                response = Console.ReadLine();
                if (InitialWorldValidation.IsValidInitialWorld(cellCount, response)) break;
                Console.WriteLine(Constants.InitialWorldInputError);
            }
            return response;
        }
        
        public void PrintWorld(World world)
        {
            var cells = world.Cells;
            int colCount = 0;
            Console.WriteLine('\n');

            foreach (var cell in cells)
            {
                if (colCount == world.WorldSize[1])
                {
                    colCount = 0;
                    Console.Write('\n');
                }
                
                Console.Write(cell.IsAlive ? '0' : '.');

                colCount++;
            }
            Console.Write('\n');
        }

        public string GetInputType()
        {
            while (true)
            {
                Console.WriteLine(Constants.InputType);
                var input = Console.ReadLine();

                switch (input)
                {
                    case "file":
                        return input;
                    case "no":
                        return input;
                }
            }
        }

        public bool KeepTicking()
        {
            return Console.ReadLine() == "t";
        }

        public bool IfSave()
        {
            return Console.ReadLine() == "s";
        }
    }
}