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
        
        public TileFloor(int x, int y) : base(x, y)
        {
            IsWalkable = true;
            this.Glyph = '.';
        }

        public TileFloor(int x, int y, int glyph, Color foregroundColor) : base(x, y, glyph, foregroundColor)
        {
            IsWalkable = true;
            this.Glyph = glyph;
            this.Foreground = foregroundColor;
        }
    }
}
