    using System;
using System.Collections.Generic;
using System.Text;
using SadConsole.Entities;
using Microsoft.Xna.Framework;

namespace SimpleSpaceRogue.Source.Engine
{
    /// <summary>
    /// A base entity which has a Position, Glyph, and Color
    /// </summary>
    public class Actor : Entity
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public Color foreColor { get; private set; }
        public Color backColor { get; private set; }
        public int glyph { get; private set; }


        public Actor(int x, int y, Color foreground, Color background, int glyph) : base(foreground, background, glyph)
        {
            this.x = x;
            this.y = y;
            this.Position = new Point(x, y);
            this.foreColor = foreground;
            this.backColor = background;
            this.glyph = glyph;
        }

        public Actor(int x, int y, int glyph) : base(1, 1)
        {
            this.x = x;
            this.y = y;
            this.Position = new Point(x, y);
            this.glyph = glyph;
        }

        public Actor(int x, int y, Color foreground, int glyph) : base(foreground, Color.Transparent, glyph)
        {
            this.x = x;
            this.y = y;
            this.Position = new Point(x, y);
            this.foreColor = foreground;
            this.glyph = glyph;
        }

        public Actor(int x, int y) : base(1, 1)
        {
            this.x = x;
            this.y = y;
            this.Position = new Point(x, y);
        }

    }
}
