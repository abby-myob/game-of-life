using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
        }
    }

    public static class WorldSizeValidation
    {
        public static bool IsValidWorldSize(string response)
        {
            var regex = new Regex(
                @"^([1-9]|[1-9][0-9]|[1-9][0-9][0-9])x([1-9]|[1-9][0-9]|[1-9][0-9][0-9])$");

            if (response != null && regex.IsMatch(response)) return true;
            return false;
        }

        public static int[] ConvertWorldSizeStringToInts(string input)
        {
            var nums = input.Split("x");
            var output = new List<int> {int.Parse(nums[0]), int.Parse(nums[1])};

            return output.ToArray();
        }
    }

    public static class InitialWorldValidation
    {
        public static bool IsValidInitialWorld(int cellCount, string response)
        {
            if (response != null)
            {
                var regex = new Regex(@"^[.0]{" + cellCount + "}$");
                if (regex.IsMatch(response)) return true;
            }

            return false;
        }
    }
}