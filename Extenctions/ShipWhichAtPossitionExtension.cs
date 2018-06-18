using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Console_Battleship.Ships;

namespace Console_Battleship.Extenctions
{
    public static class WhichAtPossitionExtension
    {
        public static Ship WhichAtPossition(this List<Ship> Ships, Point shotPositions)
        {
            return Ships.Where(
                x => x.OccupiedBlocks.Any(
                    y => y.Possition == shotPositions)
                    ).First();
        }
    }
}