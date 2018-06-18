using System.Collections.Generic;
using System.Drawing;

namespace Console_Battleship
{
    public class Board
    {
        public List<Block> Blocks { get; set; }

        public Board()
        {
            Blocks = new List<Block>();
            Point possition;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    possition = new Point(i, j);
                    Blocks.Add(new Block(possition));
                }
            }
        }
    }
}