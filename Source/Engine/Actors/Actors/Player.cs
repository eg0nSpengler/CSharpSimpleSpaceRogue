using System;
using System.Collections.Generic;
using System.Text;
using SimpleSpaceRogue.Source.Engine.Components;
using Microsoft.Xna.Framework;

namespace SimpleSpaceRogue.Source.Engine.Actors
{
    class Player : Actor
    {
        public HealthComponent healthComponent { get; set; }
        public InventoryComponent invComponent { get; set; }

        public Player(int x, int y, Color foreground, Color background, int glyph) : base(x, y, foreground, background, glyph)
        {
            healthComponent = new HealthComponent(5);
            invComponent = new InventoryComponent();
        }

    }
}
