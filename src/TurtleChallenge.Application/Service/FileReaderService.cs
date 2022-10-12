using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TurtleChallenge.Application.Model;

namespace TurtleChallenge.Application.Service
{
    public class FileReaderService
    {
        public GameSettings InitializeGame(string fileLocation)
        {
            var gameSettings = new GameSettings();

            using var fs = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);
            using var sr = new StreamReader(fs, Encoding.UTF8);

            string line = String.Empty;

            while ((line = sr.ReadLine()) != null)
            {
                string[] instruction = line.Split(',');

                var position = new Point(instruction[1], instruction[2]);

                if (line.StartsWith("Size"))
                {
                    gameSettings.HorizontalSize = position.X;
                    gameSettings.VerticalSize = position.Y;
                    continue;
                }

                gameSettings.ValidatePosition(position);

                if (line.StartsWith("Start"))
                {
                    gameSettings.StartPosition = position;
                    Enum.TryParse(instruction[3], out Orientation orientation);
                    gameSettings.InitialOrientation = orientation;
                    continue;
                }

                if (line.StartsWith("Exit"))
                {
                    gameSettings.ExitPosition = position;
                    continue;
                }

                if (line.StartsWith("Mine"))
                {
                    gameSettings.AddMine(position);
                    continue;
                }
            }

            return gameSettings;
        }

        public Queue<string> GetMoves(string fileLocation)
        {
            var moves = File.ReadAllText(fileLocation);
            return new Queue<string>(moves.Split(','));
        }
    }
}
