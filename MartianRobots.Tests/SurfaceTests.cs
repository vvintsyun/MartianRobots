using MartianRobots.Classes;

namespace MartianRobots.Tests
{
    public class SurfaceTests
    {
        [Fact]
        public void SurfaceInitWithInvalidXThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Surface("qwe 5"));
            Assert.Equal("Incorrect x surface value", ex.Message);
        }

        [Fact]
        public void SurfaceInitWithInvalidYThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Surface("5 qwe"));
            Assert.Equal("Incorrect y surface value", ex.Message);
        }

        [Fact]
        public void SurfaceInitWithNonPositiveXThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Surface("0 5"));
            Assert.Equal("Surface MaxX must have value in range from 1 to 50", ex.Message);
        }

        [Fact]
        public void SurfaceInitWithNonPositiveYThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Surface("5 0"));
            Assert.Equal("Surface MaxY must have value in range from 1 to 50", ex.Message);
        }

        [Fact]
        public void SurfaceInitIncorrectInputThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Surface("1 2 3"));
            Assert.Equal("Incorrect surface input", ex.Message);
        }

        [Fact]
        public void SurfaceInitIsCorrect()
        {
            var surface = new Surface("5 4");

            Assert.Equal(5, surface.MaxX);
            Assert.Equal(4, surface.MaxY);
        }

        [Fact]
        public void SurfaceAddDropSpotIsCorrect()
        {
            var surface = new Surface("5 4");

            surface.AddDropSpot(3, 2);

            Assert.Equal(1, surface.DropSpots.Count);
            Assert.True(surface.DropSpots.Contains((3, 2)));
        }

        [Fact]
        public void SurfaceAddInvalidDropSpotThrowsException()
        {
            var surface = new Surface("5 4");

            var ex = Assert.Throws<ArgumentException>(() => surface.AddDropSpot(-1, 11));
            Assert.Equal("Position -1 11 does not exist", ex.Message);
        }
    }
}