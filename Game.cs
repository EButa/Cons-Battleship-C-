using System;
using System.Drawing;
using Console_Battleship.Enums;

namespace Console_Battleship
{
    public class Game
    {
        public Player PlayerA { get; set; }
        public Player PlayerB { get; set; }
        private GameMode GameMode { get; set; }

        public Game(GameMode gameMode)
        {
            GameMode = gameMode;

            switch (gameMode)
            {
                case GameMode.PlayerVsComputer:
                    PlayerA = new Player("Player");
                    PlayerB = new NpcPlayer("Computer");
                    break;
                default:
                    PlayerA = new NpcPlayer("Computer1");
                    PlayerB = new NpcPlayer("Computer2");
                    break;
            }

            PlayerA.PlaceShips();
            PlayerB.PlaceShips();

        }

        private void Round()
        {
            Point shotPossition = PlayerA.FireShot();
            ShotResult result = PlayerB.ProcessShot(shotPossition);
            PlayerA.ProcessShotResult(shotPossition, result);

            if (!PlayerB.HasLost)
            {
                shotPossition = PlayerB.FireShot();
                result = PlayerA.ProcessShot(shotPossition);
                PlayerB.ProcessShotResult(shotPossition, result);
            }
        }
        public void PlayGame()
        {

            switch (GameMode)
            {
                case GameMode.PlayerVsComputer:
                    PlayerVsComputer();
                    break;
                default:
                    ComputerVsComputer();
                    break;
            }


            PlayerA.ShowBoards();
            PlayerB.ShowBoards();

            if (PlayerA.HasLost)
            {
                Console.WriteLine(PlayerB.Name + " has won the game!");
            }
            else if (PlayerB.HasLost)
            {
                Console.WriteLine(PlayerA.Name + " has won the game!");
            }

        }
        private void PlayerVsComputer()
        {
            PlayerA.ShowBoards();
            while (!PlayerA.HasLost && !PlayerB.HasLost)
            {
                Round();
                PlayerA.ShowBoards();

            }
        }
        private void ComputerVsComputer()
        {
            while (!PlayerA.HasLost && !PlayerB.HasLost)
            {
                Round();
            }
        }
    }
}