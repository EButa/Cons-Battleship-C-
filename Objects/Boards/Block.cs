using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Console_Battleship.Extenctions;

namespace Console_Battleship
{
    public class Block
    {
        public BlockType Type { get; set; }
        public Point Possition { get; set; }

        public Block(Point possition)
        {
            Possition = possition;
            Type = BlockType.Empty;
        }

        public bool IsOccupied
        {
            get
            {
                return Type != BlockType.Empty;
            }
        }

        public string Symbol
        {
            get
            {
                HandleColor();
                return Type.Description();
            }
        }

        private  void HandleColor()
        {
            switch (Type)
            {
                case BlockType.Empty:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case BlockType.Ship:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case BlockType.Hit:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case BlockType.Miss:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
}