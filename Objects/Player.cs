using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Console_Battleship.Extenctions;
using Console_Battleship.Ships;

namespace Console_Battleship
{
    public class Player
    {
        public string Name { get; set; }
        public Board GameBoard { get; set; }
        public FiringBoard FiringBoard { get; set; }
        public List<Ship> Ships { get; set; }
        public bool HasLost
        {
            get
            {
                return Ships.All(x => x.IsDestroyed);
            }
        }

        public Player(string name)
        {
            Name = name;
            GameBoard = new Board();
            FiringBoard = new FiringBoard();

            Ships = new List<Ship>()
            {
                new Destroyer(),
                new Submarine(),
                new Cruiser(),
                new Battleship(),
                new Carrier()
            };
        }

        public void PlaceShips()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            foreach (var Ship in Ships)
            {
                bool IsBlocksAvailable = true;
                while (IsBlocksAvailable)
                {
                    //Ship start position in the GameBoard
                    Point StartPoint = new Point(
                        rand.Next(0, 10),
                        rand.Next(0, 10)
                    );
                    // Ship end possition in GameBoard
                    Point EndPoint = StartPoint;
                    // 0 - horizontal, 1 - vertical
                    int orientation = rand.Next(0, 2);
                    List<int> BlocksForShipPos = new List<int>();
                    if (orientation == 0)
                    {
                        EndPoint.X += Ship.Size - 1;
                    }
                    else
                    {
                        EndPoint.Y += Ship.Size - 1;
                    }
                    // Check boundaries
                    if (EndPoint.X >= 10 || EndPoint.Y >= 10)
                    {
                        continue;
                    }
                    // Get blocks of interest
                    var BlocksAffected = GameBoard.Blocks.Range(StartPoint, EndPoint);
                    // Check if required blocks are empty
                    // if any blocks are occupied - restart loop 
                    if (BlocksAffected.Any(x => x.IsOccupied))
                    {
                        continue;
                    }

                    Ship.OccupiedBlocks = new List<Block>(BlocksAffected);
                    foreach (var Block in BlocksAffected)
                    {
                        Block.Type = Ship.Type;
                    }
                    IsBlocksAvailable = false;
                }

            }
        }

        public void ShowBoards()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Own Board:                          Firing Board:");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("  0 1 2 3 4 5 6 7 8 9                  0 1 2 3 4 5 6 7 8 9");

            for (int row = 0; row < 10; row++)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(Convert.ToChar(65 + row) + "|");
                for (int gameBoardColumn = 0; gameBoardColumn < 10; gameBoardColumn++)
                {

                    Console.Write(GameBoard.Blocks.At(row, gameBoardColumn).Symbol + " ");
                }

                Console.Write("               ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(Convert.ToChar(65 + row) + "|");
                for (int fireBoardColumn = 0; fireBoardColumn < 10; fireBoardColumn++)
                {
                    Console.Write(FiringBoard.Blocks.At(row, fireBoardColumn).Symbol + " ");
                }
                Console.Write(Environment.NewLine);
            }
            Console.WriteLine(Environment.NewLine);
        }

        private Point InputShot()
        {
            Point Position = new Point();

            Char X, Y;

            do
            {
                Console.WriteLine("Input shot possition");
                X = Char.ToUpper(Console.ReadKey().KeyChar);
                Y = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (!isInputShotValid(X, Y));

            int x = X - 65;
            int y = Y - 48;

            Position = new Point(x, y);
            return Position;
        }

        private bool isInputShotValid(Char X, Char Y)
        {
            int x = X - 65;
            int y = Y - 48;
            if (x < 0 || x >= 10 || y < 0 || y >= 10)
            {
                Console.WriteLine("Wrong input values");
                return false;
            }

            if (FiringBoard.Blocks.At(x, y).IsOccupied)
            {
                Console.WriteLine("You already shot at these coordinates");
                return false;
            }

            return true;
        }

        public virtual Point FireShot()
        {
            Point ShotCoordinates = InputShot();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Name + " shot at position " + Convert.ToChar(65 + ShotCoordinates.X) + "," + ShotCoordinates.Y);
            return ShotCoordinates;
        }

        public ShotResult ProcessShot(Point shot)
        {
            Block Block = GameBoard.Blocks.At(shot);

            if (!Block.IsOccupied)
            {
                // Block.Type = BlockType.Miss;
                return ShotResult.Miss;
            }

            Ship Ship = Ships.WhichAtPossition(shot);
            Ship.Hits++;
            //Block.Type = BlockType.Hit;
            if (Ship.IsDestroyed)
            {
                Console.WriteLine(Name + "'s ship: " + Ship.Name + " was destryed!");
            }
            return ShotResult.Hit;
        }

        public void ProcessShotResult(Point shotFired, ShotResult result)
        {
            var BlockAffected = FiringBoard.Blocks.At(shotFired);
            BlockAffected.Type = result == ShotResult.Hit ? BlockType.Hit : BlockType.Miss;
        }
    }
}