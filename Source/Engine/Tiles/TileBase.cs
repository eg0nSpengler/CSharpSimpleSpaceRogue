using System;
using System.Collections.Generic;
using System.Text;
using SadConsole;
using Microsoft.Xna.Framework;

namespace SimpleSpaceRogue.Source.Engine.Tiles
{
    /// <summary>
    /// A base tile
    /// </summary>
    public class TileBase : Cell
    {
        /// <summary>
        /// Can this tile be walked on?
        /// </summary>
        public bool IsWalkable { get; protected set; }
        /// <summary>
        /// Foreground Color
        /// </summary>
        public Color foreColor { get; private set; }
        public int glyph { get; private set; }
        public int x { get; private set; }
        public int y { get; private set; }


        public TileBase(int x, int y, int glyph)
        {
            this.x = x;
            this.y = y;
            this.glyph = glyph;
        }

        public TileBase(int x, int y, int glyph, Color foregroundColor)
        {
            this.x = x;
            this.y = y;
            this.glyph = glyph;
            foreColor = foregroundColor;
        }
    }
}
