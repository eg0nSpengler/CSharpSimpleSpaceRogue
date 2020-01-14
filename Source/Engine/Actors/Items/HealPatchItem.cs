using System;
using System.Collections.Generic;
using System.Text;
using SimpleSpaceRogue.Source.Engine.Actors.Items.Uses;
using Microsoft.Xna.Framework;



namespace SimpleSpaceRogue.Source.Engine.Actors.Items
{
    class HealPatchItem : ItemBase
    {
        public HealUse healUse { get; }

        public HealPatchItem(int x, int y, Color foreground, int glyph) : base(x, y, foreground, glyph)
        {
            healUse = new HealUse();
            
        }
    }
}
