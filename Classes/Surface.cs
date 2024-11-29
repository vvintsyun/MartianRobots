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
            if (x <= 0) 
            {
                throw new ArgumentException($"Surface MaxX must be non negative"); 
            }
            if (!int.TryParse(coordinates[1], out var y))
            {
                throw new ArgumentException("Incorrect y surface value");
            }
            if (y <= 0)
            {
                throw new ArgumentException($"Surface MaxY must be non negative");
            }

            MaxX = x;
            MaxY = y;
        }

        internal void AddDropSpot(int x, int y)
        {
            _dropSpots.Add((x, y));
        }
    }
}
