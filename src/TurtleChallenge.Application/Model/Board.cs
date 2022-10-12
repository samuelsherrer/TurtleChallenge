using System;
using System.Linq;
using System.Threading;

namespace TurtleChallenge.Application.Model
{
    public sealed class Board
    {
        public bool Finished = false;

        public Board(int x, int y)
        {
            this.Elements = new Element[x, y];
        }

        public Element AddElement(Element element)
        {
            return this.Elements[element.Position.X, element.Position.Y] = element;
        }

        public void ChangeTurtlePosition(object sender, Turtle element)
        {
            var lastPosition = element.PositionsHistory.LastOrDefault().Value;
            this.Elements[lastPosition.X, lastPosition.Y] = null!;

            Console.WriteLine(GetMessage(element.PositionsHistory.Count, element, element.Position));

            this.Elements[element.Position.X, element.Position.Y] = element;
        }

        public bool IsMineHit(Point position)
            => position.IsValid
                && position.X < this.Elements.GetLength(0)
                && position.Y < this.Elements.GetLength(1)
                && this.Elements[position.X, position.Y] is Mine;

        public bool IsExit(Point position)
            => this.Elements[position.X, position.Y] is Exit;

        private string GetMessage(int sequence, Turtle element, Point nextPosition)
        {
            string message = $"Sequence {sequence}: ";

            if (IsMineHit(nextPosition))
            {
                this.Finished = true;
                return message += "Mine Hit!";
            }

            if (IsMineHit(element.NextPosition))
            {
                return message += "Danger!";
            }

            if (IsExit(element.Position))
            {
                this.Finished = true;
                return message += "Exit!";
            }

            return message += "Success!";
        }

        public Element[,] Elements { get; private set; }
    }
}
