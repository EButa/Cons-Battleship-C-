using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Console_Battleship.Extenctions;

namespace Console_Battleship
{
    public class FiringBoard : Board
    {
        public List<Point> GetAvailableBlockPositions()
        {
            return Blocks.Where(x => x.Type == BlockType.Empty).Select(x => x.Possition).ToList();
        }

        public bool IsBlockAvailable(Point point)
        {
            return !Blocks.At(point).IsOccupied;
        }
    }
}