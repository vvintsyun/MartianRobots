using System.Collections.Immutable;

namespace MartianRobots.Classes
{
    public class Surface
    {
        public int MaxX { get; init; }
        public int MaxY { get; init; }

        private HashSet<(int, int)> _dropSpots = new HashSet<(int, int)>();

        public IImmutableSet<(int, int)> DropSpots => _dropSpots.ToImmutableHashSet();

        public Surface(string input)
        {
            var coordinates = input.Split(' ');
            if (coordinates.Length != 2)
            {
                throw new ArgumentException("Incorrect surface input");
            }
            if (!int.TryParse(coordinates[0], out var x))
            {
                throw new ArgumentException("Incorrect x surface value");
            }
            if (x <= 0 || x > 50) 
            {
                throw new ArgumentException($"Surface MaxX must have value in range from 1 to 50"); 
            }
            if (!int.TryParse(coordinates[1], out var y))
            {
                throw new ArgumentException("Incorrect y surface value");
            }
            if (y <= 0 || y > 50)
            {
                throw new ArgumentException($"Surface MaxY must have value in range from 1 to 50");
            }

            MaxX = x;
            MaxY = y;
        }

        public void AddDropSpot(int x, int y)
        {
            if (x < 0 || x > MaxX || y < 0 || y > MaxY)
                throw new ArgumentException($"Position {x} {y} does not exist");
            
            _dropSpots.Add((x, y));
        }
    }
}
