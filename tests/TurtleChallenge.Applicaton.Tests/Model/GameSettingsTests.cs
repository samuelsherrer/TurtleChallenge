using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallenge.Application.Model;
using Xunit;

namespace TurtleChallenge.Applicaton.Tests.Model
{
    public class GameSettingsTests
    {
        [Theory]
        [InlineData(-1, -1)]
        [InlineData(6, 0)]
        [InlineData(2, 7)]
        public void ValidatePosition_GivenAnOutRangePosition_ShoudlThrowAnArgumentOutOfRangeException(
            int x,
            int y)
        {
            // Arrange
            var point = new Point(x, y);
            var gameSettings = new GameSettings()
            {
                HorizontalSize = 5,
                VerticalSize = 5
            };

            // Act, Assert 
            Assert.Throws<ArgumentOutOfRangeException>(() => gameSettings.ValidatePosition(point));
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(5, 5)]
        [InlineData(2, 4)]
        public void AddMine_GivenAnElement_ShoudlBeInTheList(
            int x,
            int y)
        {
            // Arrange
            var point = new Point(x, y);
            var gameSettings = new GameSettings()
            {
                HorizontalSize = 5,
                VerticalSize = 5
            };

            // Act
            gameSettings.AddMine(point);

            // Assert
            Assert.NotNull(gameSettings.Mines);
            Assert.Equal(point, gameSettings.Mines.Last());
        }
    }
}
