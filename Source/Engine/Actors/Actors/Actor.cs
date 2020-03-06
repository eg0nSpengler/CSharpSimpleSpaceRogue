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
        /// <summary>
        /// The glyph used to represent the Actor
        /// </summary>
       public int Glyph { get; }

        /// <summary>
        /// A base entity which has a Position, Glyph, and Color
        /// </summary>
        /// <param name="x">X Position</param>
        /// <param name="y">Y Position</param>
        /// <param name="foreground">Actor Foreground Color</param>
        /// <param name="background">Actor Background Color</param>
        /// <param name="glyph">The glyph to represent the Actor</param>
        public Actor(int x, int y, Color foreground, Color background, int glyph) : base(foreground, background, glyph)
        {
            this.Position = new Point(x, y);
            this.DefaultForeground = foreground;
            this.DefaultBackground = background;
            this.Glyph = glyph;
        }

        /// <summary>
        /// A base entity which has a Position, Glyph, and Color
        /// </summary>
        /// <param name="x">X Position</param>
        /// <param name="y">Y Position</param>
        /// <param name="glyph">The glyph to represent the Actor</param>
        public Actor(int x, int y, int glyph) : base(1, 1)
        {
            this.Position = new Point(x, y);
            this.Glyph = glyph;
        }

        /// <summary>
        /// A base entity which has a Position, Glyph, and Color
        /// </summary>
        /// <param name="x">X Position</param>
        /// <param name="y">Y Position</param>
        /// <param name="foreground">Actor Foreground Color</param>
        /// <param name="glyph">The glyph to represent the Actor</param>
        public Actor(int x, int y, Color foreground, int glyph) : base(foreground, Color.Transparent, glyph)
        {
            this.Position = new Point(x, y);
            this.DefaultForeground = foreground;
            this.Glyph = glyph;
        }

        /// <summary>
        /// A base entity which has a Position, Glyph, and Color
        /// </summary>
        /// <param name="x">X Position</param>
        /// <param name="y">Y Position</param>
        public Actor(int x, int y) : base(1, 1)
        {
            this.Position = new Point(x, y);
        }

    }
}
