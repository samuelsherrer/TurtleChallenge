namespace TurtleChallenge.Application.Model
{
    public class Game
    {
        public Game(int x, int y)
        {
            Board = new Board(x, y);
        }

        public Board Board { get; set; }
    }
}
