using MartianRobots.Classes;

var input = @"5 3
1 1 E
RFRFRFRF

3 2 N
FRRFLLFFRRFLL

0 3 W
LLFFFLFLFL";

Console.WriteLine(Parser.Parse(input));

Console.ReadLine();
