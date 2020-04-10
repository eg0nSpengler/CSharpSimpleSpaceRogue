using System;
using System.Collections.Generic;
using System.Text;
using SadConsole;
using Microsoft.Xna.Framework;

namespace SimpleSpaceRogue.Source.Engine.Tiles
{
    /// <summary>
    /// A walkable floor tile
    /// </summary>
    public class TileFloor : Tile
    {
        public TileFloor(int x, int y, int glyph) : base(x, y, glyph)
        {
            IsWalkable = true;
        }

        public TileFloor(int x, int y, int glyph, Color foregroundColor) : base(x, y, glyph, foregroundColor)
        {
            IsWalkable = true;
        }
    }
}
