using System;
using System.Collections.Generic;

namespace TurtleChallenge.Application.Model
{
    public class GameSettings
    {
        public int HorizontalSize { get; set; }

        public int VerticalSize { get; set; }

        public Point StartPosition { get; set; }

        public Point ExitPosition { get; set; }

        public Orientation InitialOrientation { get; set; }

        public List<Point> Mines { get; set; } = new List<Point>();

        public void AddMine(Point point)
        {
            this.ValidatePosition(point);
            this.Mines.Add(point);
        }

        public void ValidatePosition(Point point)
        {
            if (point.X < 0 || point.X > HorizontalSize)
                throw new ArgumentOutOfRangeException(nameof(point));

            if (point.X < 0 || point.Y > VerticalSize)
                throw new ArgumentOutOfRangeException(nameof(point));
        }
    }
}
