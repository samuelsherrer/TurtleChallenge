using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallenge.Application.Model;
using Xunit;

namespace TurtleChallenge.Applicaton.Tests.Model
{
    public class BoardTests
    {
        [Fact]
        public void AddElement_GivenAnElement_ShouldPutInTheRightPosition()
        {
            // Arrange
            var board = new Board(5, 5);
            var position = new Point(3, 2);
            var mine = new Mine(position);

            // Act
            board.AddElement(mine);

            // Assert
            Assert.NotNull(board.Elements[position.X, position.Y]);
            Assert.Equal(mine, board.Elements[position.X, position.Y]);
        }

        [Fact]
        public void ChangeTurtlePosition_GivenATurtle_ShouldClearPositionAndPutInTheNewOne()
        {
            // Arrange
            var board = new Board(5, 5);
            var initialPosition = new Point(3, 2);
            var expectedPosition = new Point(2, 2);
            var turtle = new Turtle(initialPosition, Orientation.North);

            // Act
            turtle.Move();
            board.ChangeTurtlePosition(null, turtle);
            var lastPosition = turtle.PositionsHistory.Last().Value;

            // Assert
            Assert.Equal(initialPosition, lastPosition);
            Assert.Null(board.Elements[lastPosition.X, lastPosition.Y]);
            Assert.NotNull(board.Elements[expectedPosition.X, expectedPosition.Y]);
            Assert.Equal(turtle, board.Elements[expectedPosition.X, expectedPosition.Y]);
        }

        [Fact]
        public void IsMineHit_GivenSamePosition_ShouldBeHit()
        {
            // Arrange
            var board = new Board(5, 5);
            var position = new Point(3, 2);
            var mine = new Mine(position);

            // Act
            board.AddElement(mine);

            // Assert
            Assert.True(board.IsMineHit(position));
        }

        [Fact]
        public void IsMineHit_GivenDifferentPosition_ShouldBeFalse()
        {
            // Arrange
            var board = new Board(5, 5);
            var position = new Point(3, 2);
            var mine = new Mine(position);

            // Act
            board.AddElement(mine);

            // Assert
            Assert.False(board.IsMineHit(new Point(3, 3)));
        }
    }
}
