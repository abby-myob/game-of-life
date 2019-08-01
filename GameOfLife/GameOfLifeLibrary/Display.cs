using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GameOfLifeLibrary
{
    public static class Display
    {
        public static void DisplayWelcome()
        {
            Console.WriteLine(Constants.Welcome);
        }
        
        public static int[] GetWorldSize()
        {
            string response;
            Console.WriteLine(Constants.DefineWorldSize);
            while (true)
            {
                response = Console.ReadLine();
                Regex regex = new Regex(
                    @"^([1-9]|[1-9][0-9]|[1-9][0-9][0-9])x([1-9]|[1-9][0-9]|[1-9][0-9][0-9])$");

                if (response != null && regex.IsMatch(response)) break;

                Console.WriteLine(Constants.WorldSizeInputError);
            }

            return ConvertWorldSize(response);
        }
        
        public static int[] ConvertWorldSize(string input)
        {
            var nums = input.Split("x");
            var output = new List<int> {int.Parse(nums[0]), int.Parse(nums[1])};
            
            return output.ToArray();
        }

        
        public static string GetInitialInput(int cellCount)
        {
            Console.WriteLine(Constants.SetInitialState);
            string response;

            while (true)
            {
                response = Console.ReadLine();
                if (response != null)
                {
                    var regex = new Regex(@"^[.0]{" + cellCount + "}$");
                    if (regex.IsMatch(response)) break;
                }
                Console.WriteLine(Constants.InitialWorldInputError);
            }
            return response;
        }

        public static void PrintWorld(World world)
        {
            var cells = world.Cells;
            int colCount = 0;
            Console.Write('\n');

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
}