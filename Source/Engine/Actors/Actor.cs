using System;
using System.Collections.Generic;
using System.Text;
using SadConsole.Entities;
using Microsoft.Xna.Framework;

namespace SimpleSpaceRogue.Source.Engine
{
    public class Actor : Entity
    {
        public int m_X { get; private set; }
        public int m_Y { get; private set; }
        public Color m_foreColor { get; private set; }
        public Color m_backColor { get; private set; }
        public int m_glyph { get; private set; }


        public Actor(int x, int y, Color foreground, Color background, int glyph) : base(foreground, background, glyph)
        {
            m_X = x;
            m_Y = y;
            m_foreColor = foreground;
            m_backColor = background;
            m_glyph = glyph;
            Position = new Point(x, y);
        }


    }
}
