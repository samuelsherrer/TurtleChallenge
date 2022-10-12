using System;
using System.Collections.Generic;
using System.Linq;
using TurtleChallenge.Application.Model;

namespace TurtleChallenge.Application.Service
{
    public class GameService
    {
        private readonly FileReaderService fileReaderService;

        public GameService()
        {
            this.fileReaderService = new FileReaderService();
        }

        public void Start(string[] args)
        {
            try
            {
                if (args.Count() < 2)
                    throw new ArgumentException(nameof(args));

                var gameSettingsFileLocation = args[0];

                if (string.IsNullOrEmpty(gameSettingsFileLocation))
                    throw new ArgumentNullException(nameof(gameSettingsFileLocation), "Missing game settings file.");

                var movesFileLocation = args[1];

                if (string.IsNullOrEmpty(movesFileLocation))
                    throw new ArgumentNullException(nameof(movesFileLocation), "Missing moves file.");

                var gameSettings = fileReaderService.InitializeGame(gameSettingsFileLocation);
                var moves = fileReaderService.GetMoves(movesFileLocation);

                var game = new Game(gameSettings.HorizontalSize, gameSettings.VerticalSize);

                if (!moves.Any())
                {
                    Console.WriteLine("There are no moves, please check your moves file.");
                    return;
                }

                foreach (var mine in gameSettings.Mines)
                {
                    game.Board.AddElement(new Mine(mine));
                }

                game.Board.AddElement(new Exit(gameSettings.ExitPosition));

                var turtle = (Turtle)game.Board.AddElement(new Turtle(gameSettings.StartPosition, gameSettings.InitialOrientation));
                turtle.ProcessCompleted += game.Board.ChangeTurtlePosition;

                while (moves.Count > 0)
                {
                    Console.WriteLine(new string('-', 10));

                    string move = moves.Dequeue();

                    if (move.ToLower().Equals("r"))
                    {
                        turtle.Rotate();
                        continue;
                    }

                    if (move.ToLower().Equals("m"))
                    {
                        turtle.Move();
                    }

                    if (game.Board.Finished)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
