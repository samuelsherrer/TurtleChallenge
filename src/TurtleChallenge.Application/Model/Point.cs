namespace TurtleChallenge.Application.Model
{
    public struct Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(string x, string y)
        {
            X = int.Parse(x);
            Y = int.Parse(y);
        }

        public bool IsValid
        {
            get
            {
                return this.X >= 0 && this.Y >= 0;
            }
        }

        public override string ToString()
        {
            return $"X: {X} Y: {Y}";
        }
    }
}
