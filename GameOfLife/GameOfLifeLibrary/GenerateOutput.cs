using System.Linq;
using System.Text;

namespace GameOfLifeLibrary
{
    public class GenerateOutput
    {
        public static string[] GetOutput(World world)
        {
            int colCount = 0;
            string[] result = new string[world.WorldSize[0]];

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var cell in world.Cells)
            {
                if (colCount == world.WorldSize[1])
                {
                    colCount = 0;
                    result.Append(stringBuilder.ToString());
                    stringBuilder = new StringBuilder();
                }

                stringBuilder.Append(cell.IsAlive ? " 0 " : " . ");

                colCount++;
            }

            return result;
        }

        public static string GetOutputString(World world)
        {
            int colCount = 0;
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var cell in world.Cells)
            {
                if (colCount == world.WorldSize[1])
                {
                    colCount = 0;
                    stringBuilder.Append("\n");
                }

                stringBuilder.Append(cell.IsAlive ? " 0 " : " . ");

                colCount++;
            }

            return stringBuilder.ToString();
        }
    }
}