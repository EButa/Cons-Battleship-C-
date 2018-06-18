using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Console_Battleship.Ships
{
    public abstract class Ship
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public int Hits { get; set; }
        public List<Block> OccupiedBlocks { get; set; }
        public BlockType Type { get; set; }
        public bool IsDestroyed
        {
            get
            {
                return Hits >= Size;
            }
        }
        public Ship()
        {
            this.Type = BlockType.Ship;
        }
    }
}