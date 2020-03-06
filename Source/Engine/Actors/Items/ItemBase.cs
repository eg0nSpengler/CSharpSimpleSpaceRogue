using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace SimpleSpaceRogue.Source.Engine.Actors.Items
{
    /// <summary>
    /// A base class for an Item, an Actor that can be placed inside of an Inventory
    /// </summary>
    class ItemBase : Actor
    {
        public ItemBase(int x, int y, Color foreground, int glyph) : base(x, y, foreground, glyph)
        {
           
        }
    }
}
