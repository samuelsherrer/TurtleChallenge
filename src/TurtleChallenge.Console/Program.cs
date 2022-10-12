using System;
using TurtleChallenge.Application.Service;

namespace TurtleChallenge.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("Starting...");

            var gameService = new GameService();
            gameService.Start(args);
        }
    }
}