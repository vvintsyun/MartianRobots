using MartianRobots.Classes;
using System.Text;

var input = @"5 3
1 1 E
RFRFRFRF

3 2 N
FRRFLLFFRRFLL

0 3 W
LLFFFLFLFL";

var lines = input.Split(Environment.NewLine);
var surface = new Surface(lines[0]);

var output = new StringBuilder();

ParseRobots(lines, surface, output);

Console.Write(output.ToString());

Console.ReadLine();

void ParseRobots(string[] lines, Surface surface, StringBuilder output)
{
    for (int i = 1; i <= lines.Length - 2; i = i + 3)
    {
        var robot = new Robot(lines[i], surface);
        output.AppendLine(robot.GetFinalCoordinates(lines[i + 1]));
    }

    if (output.Length > 0) {
        output.Remove(output.Length - 2, 2);
    }
}
