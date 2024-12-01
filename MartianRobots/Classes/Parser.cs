using System.Text;

namespace MartianRobots.Classes
{
    public static class Parser
    {
        public static string Parse(string input)
        {
            var lines = input.Split(Environment.NewLine);
            var surface = new Surface(lines[0]);

            var output = new StringBuilder();

            ParseRobots(lines, surface, output);

            return output.ToString();
        }

        private static void ParseRobots(string[] lines, Surface surface, StringBuilder output)
        {
            for (int i = 1; i <= lines.Length - 2; i = i + 3)
            {
                var robot = new Robot(lines[i], surface);
                output.AppendLine(robot.GetFinalCoordinates(lines[i + 1]));
            }

            if (output.Length > 0)
            {
                output.Remove(output.Length - 2, 2);
            }
        }
    }    
}
