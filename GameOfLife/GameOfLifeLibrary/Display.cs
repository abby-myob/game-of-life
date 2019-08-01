using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GameOfLifeLibrary
{
    public class Display
    {
        public static void DisplayWelcome()
        {
            Console.WriteLine(Constants.Welcome);
        }

        public static int[] GetWorldSize()
        {
            string response = "9x9";
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
            var output = new List<int>();

            output.Add(int.Parse(nums[0]));
            output.Add(int.Parse(nums[1]));

            return output.ToArray();
        }

        
        public static string GetInitialInput()
        {
            Console.WriteLine(Constants.SetInitialState);

            return null;
        }

        public static void PrintWorld(World world)
        {
            //print the currently world
        }
    }
}