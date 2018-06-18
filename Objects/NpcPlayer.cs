using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Console_Battleship
{
    public class NpcPlayer : Player
    {
        public NpcPlayer(string name) : base(name) { }

        public override Point FireShot()
        {
            Point ShotCoordinates = FindShot();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Name + " shot at position " + Convert.ToChar(65 + ShotCoordinates.X) + "," + ShotCoordinates.Y);
            return ShotCoordinates;
        }

        private Point FindShot()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var HitNeighbors = FiringBoard.GetAvailableBlockPositions();

            return HitNeighbors[rand.Next(HitNeighbors.Count)];
        }
    }
}