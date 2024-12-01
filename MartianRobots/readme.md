To run the project please open MartianRobots.sln file and run default project.
There are also tests in MartianRobots.Test project to test the algorithm.


Implementation details:
There are 2 main classes: Robot and Surface.
* Surface describes the grid where robots can move. It contains size fields (X, Y) and set of coordinates where robots were lost (DropSpots).
* Robot describes robots which can make moves on a provided surface. It has initial coordinates with orientation (X, Y, Orientation). Robot is able to move with provided move instructions (method GetFinalCoordinates, which returns final coordinates).
Utility class Parser is used to parse an input and return corresponding output.