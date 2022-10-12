using System.Linq;
using TurtleChallenge.Application.Model;
using Xunit;

namespace TurtleChallenge.Applicaton.Tests.Model
{
    public class TurtleTests
    {
        [Theory]
        [InlineData(3, 2, Orientation.North, 2, 2)]
        [InlineData(3, 2, Orientation.South, 4, 2)]
        [InlineData(3, 2, Orientation.East, 3, 3)]
        [InlineData(3, 2, Orientation.West, 3, 1)]
        public void Move_GivenAnOrientation_ShouldMoveToTheCorrectPositionAndAddToHistory(
            int initialX,
            int initialY,
            Orientation orientation,
            int expectedX,
            int expectedY)
        {
            // Arrange
            var position = new Point(initialX, initialY);
            var turtle = new Turtle(position, orientation);
            var expectedPosition = new Point(expectedX, expectedY);

            // Act
            turtle.Move();

            // Assert
            Assert.NotNull(turtle.PositionsHistory);
            Assert.Equal(position, turtle.PositionsHistory.Last().Value);
            Assert.Equal(expectedPosition, turtle.Position);
        }

        [Theory]
        [InlineData(3, 2, Orientation.North, 2, 2)]
        [InlineData(3, 2, Orientation.South, 4, 2)]
        [InlineData(3, 2, Orientation.East, 3, 3)]
        [InlineData(3, 2, Orientation.West, 3, 1)]
        public void Move_GivenAnOrientation_ShouldHaveTheCorrectNextPosition(
            int initialX,
            int initialY,
            Orientation orientation,
            int expectedX,
            int expectedY)
        {
            // Arrange
            var position = new Point(initialX, initialY);
            var turtle = new Turtle(position, orientation);
            var expectedPosition = new Point(expectedX, expectedY);

            // Act
            Assert.Equal(expectedPosition, turtle.NextPosition);
        }

        [Theory]
        [InlineData(Orientation.North, Orientation.East)]
        [InlineData(Orientation.South, Orientation.West)]
        [InlineData(Orientation.East, Orientation.South)]
        [InlineData(Orientation.West, Orientation.North)]
        public void Rotate_GivenAnOrientation_ShouldRotateToTheCorrectPositionAndAddToHistory(
            Orientation orientation,
            Orientation expectedOrientation)
        {
            // Arrange
            var position = new Point(3, 3);
            var turtle = new Turtle(position, orientation);

            // Act
            turtle.Rotate();

            // Assert
            Assert.NotNull(turtle.PositionsHistory);
            Assert.Equal(orientation, turtle.PositionsHistory.Last().Key);
            Assert.Equal(expectedOrientation, turtle.Orientation);
        }
    }
}
