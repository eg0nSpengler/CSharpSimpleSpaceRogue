using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace SimpleSpaceRogue.Source.Engine.Tiles
{
    /// <summary>
    /// An impassable wall tile
    /// </summary>
    public class TileWall : Tile
    {

        public TileWall(int x, int y) : base(x, y)
        {
            IsWalkable = false;
            this.Glyph = 'X';
        }

        public TileWall(int x, int y, int glyph, Color foregroundColor) : base(x, y, glyph, foregroundColor)
        {
            IsWalkable = false;
            this.Glyph = glyph;
            this.Foreground = foregroundColor;
        }

    }
}
