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
    public class Tile : Cell
    {
        /// <summary>
        /// Can this tile be walked on?
        /// </summary>
        public bool IsWalkable { get; set; }

        /// <summary>
        /// Can this tile be seen through? (Glass windows, for example)
        /// </summary>
        public bool IsTransparent { get; set; }

        /// <summary>
        /// Has this tile been seen/explored? (FOV-related)
        /// </summary>
        public bool IsExplored { get; set; }

        public Point Position { get; }

        /// <summary>
        /// The bounding box for this tile
        /// </summary>
        public BoundingBox Box { get; }

        public Tile(int x, int y, int glyph)
        {
            this.Position = new Point(x, y);
            this.Glyph = glyph;
            this.Box = new BoundingBox(new Vector3(x, y, 1.0f), new Vector3(1.0f));
        }

        public Tile(int x, int y, int glyph, Color foregroundColor)
        {
            this.Position = new Point(x, y);
            this.Glyph = glyph;
            this.Foreground = foregroundColor;
            this.Box = new BoundingBox(new Vector3(x, y, 1.0f), new Vector3(1.0f));
        }

        public Tile(int x, int y)
        {
            this.Position = new Point(x, y);
            this.Box = new BoundingBox(new Vector3(x, y, 1.0f), new Vector3(1.0f));
        }
    }
}
