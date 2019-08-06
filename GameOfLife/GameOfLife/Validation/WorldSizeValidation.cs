using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GameOfLife
{
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
}