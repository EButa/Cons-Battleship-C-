using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Console_Battleship.Extenctions
{
    public static class BlockAtExtension
    {

        public static Block At(this List<Block> Blocks, int row, int column)
        {
            return Blocks.Where(x => x.Possition.X == row
                                   && x.Possition.Y == column
            ).First();
        }

        public static Block At(this List<Block> Blocks, Point point)
        {
            return Blocks.Where(x => x.Possition.X == point.X
                                   && x.Possition.Y == point.Y
            ).First();
        }
    }
}