namespace TurtleChallenge.Application.Model
{
    public abstract class Element
    {
        public Element(Point position)
        {
            Position = position;
        }

        public Point Position { get; private set; }

        public void ChangePosition(Point position)
        {
            System.Console.WriteLine($"Moving to: {position}");
            this.Position = position;
        }
    }
}
