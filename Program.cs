using System;
using System.Drawing;
using Console_Battleship.Enums;

namespace Console_Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            // ComputerVsComputer or PlayerVsComputer
            Game game = new Game(GameMode.ComputerVsComputer);
            game.PlayGame();
            Console.ReadKey();
        }
    }
}
