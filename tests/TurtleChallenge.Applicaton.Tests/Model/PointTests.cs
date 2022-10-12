using TurtleChallenge.Application.Model;
using Xunit;

namespace TurtleChallenge.Applicaton.Tests.Model
{
    public class PointTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 10)]
        [InlineData(5, 0)]
        [InlineData(50, 110)]
        public void IsValid_GivenAValidPosition_ShouldBeTrue(int x, int y)
        {
            // Arrange, Act
            var position = new Point(x, y);

            // Assert 
            Assert.True(position.IsValid);
        }

        [Theory]
        [InlineData(0, -1)]
        [InlineData(-1, 0)]
        [InlineData(-1, -1)]
        public void IsValid_GivenAnInvalidPosition_ShouldBeFalse(int x, int y)
        {
            // Arrange, Act
            var position = new Point(x, y);

            // Assert 
            Assert.False(position.IsValid);
        }
    }
}
