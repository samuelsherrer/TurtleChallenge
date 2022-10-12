using System;
using System.Collections.Generic;

namespace TurtleChallenge.Application.Model
{
    public class Turtle : Element
    {
        public event EventHandler<Turtle> ProcessCompleted;

        public HashSet<KeyValuePair<Orientation, Point>> PositionsHistory { get; private set; }

        public Turtle(Point position, Orientation orientation)
            : base(position)
        {
            this.Orientation = orientation;
            this.PositionsHistory = new HashSet<KeyValuePair<Orientation, Point>>();
        }

        public Orientation Orientation { get; set; }

        public void Move()
        {
            this.PositionsHistory.Add(new(this.Orientation, this.Position));

            this.ChangePosition(this.NextPosition);

            OnProcessCompleted(this);
        }

        public void Rotate()
        {
            this.PositionsHistory.Add(new(this.Orientation, this.Position));

            this.Orientation = this.Orientation switch
            {
                Orientation.North => Orientation.East,
                Orientation.South => Orientation.West,
                Orientation.East => Orientation.South,
                Orientation.West => Orientation.North,
                _ => throw new NotImplementedException()
            };

            Console.WriteLine($"Rotated: {this.Orientation}");

            OnProcessCompleted(this);
        }

        public Point NextPosition
        {
            get
            {
                switch (this.Orientation)
                {
                    case Orientation.North:
                        return new Point(this.Position.X - 1, this.Position.Y);
                    case Orientation.South:
                        return new Point(this.Position.X + 1, this.Position.Y);
                    case Orientation.East:
                        return new Point(this.Position.X, this.Position.Y + 1);
                    case Orientation.West:
                        return new Point(this.Position.X, this.Position.Y - 1);
                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(Orientation), $"Not expected orientation value: {Orientation}");
                }
            }
        }

        protected virtual void OnProcessCompleted(Turtle eventArgs)
        {
            ProcessCompleted?.Invoke(this, eventArgs);
        }
    }
}
