using System;
using System.Collections.Generic;
using System.Text;
using SadConsole;
using Microsoft.Xna.Framework;

namespace SimpleSpaceRogue.Source.Engine.Tiles
{
    public class TileBase : Cell
    {
        public Color m_foreColor { get; set; }
        public int m_glyph { get; set; }
        public int m_X { get; set; }
        public int m_Y { get; set; }

        public TileBase(int x, int y, int glyph)
        {
            m_X = x;
            m_Y = y;
            m_glyph = glyph;
        }
    }
}
