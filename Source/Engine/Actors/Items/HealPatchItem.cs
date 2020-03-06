using System;
using System.Collections.Generic;
using System.Text;
using SimpleSpaceRogue.Source.Engine.Actors.Items.Uses;
using SimpleSpaceRogue.Source.Engine.Components;
using Microsoft.Xna.Framework;



namespace SimpleSpaceRogue.Source.Engine.Actors.Items
{
    /// <summary>
    /// A patch that heals damage inflicted on an actor
    /// </summary>
    class HealPatchItem : ItemBase, IConsumable
    {
        public HealUse healUse;

        public HealPatchItem(int x, int y) : base(x, y, Color.LightSalmon, '!')
        {
            healUse = new HealUse();
        }

        public void Consume()
        {
          
        }
    }
}
