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
            string[] worldStrings =  GenerateOutput.GetOutput(world);
            Console.WriteLine('\n');
            foreach (var line in worldStrings)
            {
                Console.WriteLine(line);
            }
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