using MartianRobots.Classes;

namespace MartianRobots.Tests
{
    public class RobotTests
    {
        [Fact]
        public void RobotInitWithInvalidXThrowsException()
        {
            var surface = new Surface("5 5");

            var ex = Assert.Throws<ArgumentException>(() => new Robot("1Q 1 W", surface));
            Assert.Equal("Incorrect X value", ex.Message);
        }

        [Fact]
        public void RobotInitWithInvalidYThrowsException()
        {
            var surface = new Surface("5 5");

            var ex = Assert.Throws<ArgumentException>(() => new Robot("1 1Q W", surface));
            Assert.Equal("Incorrect Y value", ex.Message);
        }

        [Fact]
        public void RobotInitWithNonPositiveXThrowsException()
        {
            var surface = new Surface("5 5");

            var ex = Assert.Throws<ArgumentException>(() => new Robot("-1 1 W", surface));
            Assert.Equal("Incorrect X value", ex.Message);
        }

        [Fact]
        public void RobotInitWithNonPositiveYThrowsException()
        {
            var surface = new Surface("5 5");

            var ex = Assert.Throws<ArgumentException>(() => new Robot("1 -1 W", surface));
            Assert.Equal("Incorrect Y value", ex.Message);
        }

        [Fact]
        public void RobotInitIncorrectInputThrowsException()
        {
            var surface = new Surface("5 5");
            
            var ex = Assert.Throws<ArgumentException>(() => new Robot("1 1 Q W E", surface));
            Assert.Equal("Incorrect robot input", ex.Message);
        }

        [Fact]
        public void RobotInitWithInvalidOrientationThrowsException()
        {
            var surface = new Surface("5 5");

            var ex = Assert.Throws<ArgumentException>(() => new Robot("1 1 Q", surface));
            Assert.Equal("Incorrect Orientation value", ex.Message);
        }

        [Fact]
        public void RobotInitWithNullSurfaceThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Robot("1 1 W", null));
            Assert.Equal("Surface cannot be null", ex.Message);
        }
        
        [Fact]
        public void RobotMoveLonger100ThrowsException()
        {
            var surface = new Surface("5 5");
            var robot = new Robot("0 1 S", surface);

            var ex = Assert.Throws<ArgumentException>(() => robot.GetFinalCoordinates("LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL"));
            Assert.Equal("Move instruction should not exceed 100 characters", ex.Message);
        }

        [Fact]
        public void RobotInitIsCorrect()
        {
            var surface = new Surface("5 5");
            var robot = new Robot("0 1 S", surface);

            Assert.Equal(0, robot.X);
            Assert.Equal(1, robot.Y);
            Assert.Equal(Orientation.S, robot.Orientation);
        }

        [Fact]
        public void RobotMovementIsCorrect()
        {
            var surface = new Surface("5 3");
            var robot = new Robot("1 1 E", surface);

            Assert.Equal("1 3 N", robot.GetFinalCoordinates("RFRFRFRFLFF"));
        }

        [Fact]
        public void RobotLostScentIsUsedCorrect()
        {
            var surface = new Surface("5 3");
            var robot1 = new Robot("3 2 N", surface);
            var robot2 = new Robot("0 3 W", surface);            

            Assert.Equal("3 3 N LOST", robot1.GetFinalCoordinates("FRRFLLFFRRFLL"));
            Assert.Equal("2 3 S", robot2.GetFinalCoordinates("LLFFFLFLFL"));
        }

        [Fact]
        public void RobotInvalidMoveThrowsException()
        {
            var surface = new Surface("5 5");
            var robot = new Robot("1 1 E", surface);

            var ex = Assert.Throws<NotImplementedException>(() => robot.GetFinalCoordinates("FRLQ"));
            Assert.Equal("Not implemented instruction Q", ex.Message);
        }

        
    }
}