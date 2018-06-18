using System.ComponentModel;

namespace Console_Battleship
{
    public enum BlockType
    {
        //[Description("⨀")]
        [Description("o")]
        Empty,

        //[Description("□")]
        [Description("S")]
        Ship,
        
        //[Description("■")]
        [Description("H")]
        Hit,
        
        //[Description("⬤")]
        [Description("M")]
        Miss,
    }
}