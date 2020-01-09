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
            foreColor = foreground;
            backColor = background;
            this.glyph = glyph;
            Position = new Point(x, y);
        }


    }
}
