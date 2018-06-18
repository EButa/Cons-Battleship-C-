using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Console_Battleship.Extenctions
{
    public static class BlockRangeExtention
    {

        public static List<Block> Range(this List<Block> Blocks, Point startPoint, Point endPoint)
        {
            return Blocks.Where(
                x => x.Possition.X >= startPoint.X
                    && x.Possition.Y >= startPoint.Y
                    && x.Possition.X <= endPoint.X
                    && x.Possition.Y <= endPoint.Y
            ).ToList();
        }
    }
}