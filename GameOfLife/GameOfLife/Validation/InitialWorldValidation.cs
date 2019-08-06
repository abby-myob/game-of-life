using System.Text.RegularExpressions;

namespace GameOfLife
{
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