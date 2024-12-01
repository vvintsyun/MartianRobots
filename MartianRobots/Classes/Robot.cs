namespace MartianRobots.Classes
{
    public class Robot
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Orientation Orientation { get; private set; }

        private Surface Surface { get; init; }

        public Robot(string input, Surface surface)
        {
            var values = input.Split(' ');
            if (values.Length != 3 )
            {
                throw new ArgumentException("Incorrect robot input");
            }

            if (!int.TryParse(values[0], out var x) || x < 0) 
            {
                throw new ArgumentException($"Incorrect {nameof(X)} value");
            }

            if (!int.TryParse(values[1], out var y) || y < 0)
            {
                throw new ArgumentException($"Incorrect {nameof(Y)} value");
            }

            if (!Enum.TryParse(values[2], true, out Orientation orientation))
            {
                throw new ArgumentException($"Incorrect {nameof(Orientation)} value");
            }

            if (surface is null)
            {
                throw new ArgumentException($"{nameof(Surface)} cannot be null");
            }

            X = x;
            Y = y;
            Orientation = orientation;
            Surface = surface;
        }


        public string GetFinalCoordinates(string move)
        {
            if (move.Length > 100)
            {
                throw new ArgumentException("Move instruction should not exceed 100 characters");
            }

            for (int i = 0; i < move.Length; i++)
            {
                switch (move[i]) {
                    case 'L': 
                        {
                            switch (Orientation)
                            {
                                case Orientation.N: Orientation = Orientation.W; break;
                                case Orientation.W: Orientation = Orientation.S; break;
                                case Orientation.S: Orientation = Orientation.E; break;
                                case Orientation.E: Orientation = Orientation.N; break;
                                default: throw new NotImplementedException("Not implemented rotation");
                            }
                            break;
                        }
                    case 'R':
                        {
                            switch (Orientation)
                            {
                                case Orientation.N: Orientation = Orientation.E; break;
                                case Orientation.W: Orientation = Orientation.N; break;
                                case Orientation.S: Orientation = Orientation.W; break;
                                case Orientation.E: Orientation = Orientation.S; break;
                                default: throw new NotImplementedException("Not implemented rotation");
                            }
                            break;
                        }
                    case 'F':
                        {
                            switch (Orientation)
                            {
                                case Orientation.N: 
                                    if (!TrySetY(true))
                                    {
                                        Surface.AddDropSpot(X, Y);
                                        return GetPosition(true);
                                    }
                                    break;
                                case Orientation.W:
                                    if (!TrySetX(false))
                                    {
                                        Surface.AddDropSpot(X, Y);
                                        return GetPosition(true);
                                    }
                                    break;
                                case Orientation.S:
                                    if (!TrySetY(false))
                                    {
                                        Surface.AddDropSpot(X, Y);
                                        return GetPosition(true);
                                    }
                                    break;
                                case Orientation.E:
                                    if (!TrySetX(true))
                                    {
                                        Surface.AddDropSpot(X, Y);
                                        return GetPosition(true);
                                    }
                                    break;
                                default: throw new NotImplementedException("Not implemented move");
                            }
                            break;
                        }
                    default: throw new NotImplementedException($"Not implemented instruction {move[i]}");
                }
            }

            return GetPosition(false);
        }

        private bool TrySetX(bool isIncreased)
        {
            var newValue = X + (isIncreased ? 1 : -1);
            if (newValue <= Surface.MaxX && newValue >= 0)
            {
                X = newValue;
                return true;
            }
            else if (!Surface.DropSpots.Contains((X, Y)))
            {
                return false;
            }

            return true;
        }

        private bool TrySetY(bool isIncreased)
        {
            var newValue = Y + (isIncreased ? 1 : -1);
            if (newValue <= Surface.MaxY && newValue >= 0)
            {
                Y = newValue;
                return true;
            }
            else if (!Surface.DropSpots.Contains((X, Y)))
            {
                return false;
            }

            return true;
        }

        private string GetPosition(bool isLost)
        {
            if (isLost)
            {
                return $"{X} {Y} {Orientation} LOST";
            }
            
            return $"{X} {Y} {Orientation}";
        }
    }
}
