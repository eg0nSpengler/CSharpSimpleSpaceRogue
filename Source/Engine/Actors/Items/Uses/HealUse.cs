using System;
using System.Collections.Generic;
using System.Text;
using SimpleSpaceRogue.Source.Engine.Components;
using Microsoft.Xna.Framework;

namespace SimpleSpaceRogue.Source.Engine.Actors.Items.Uses
{
    class HealUse : BaseUse
    {
        public void Use(HealthComponent healthComp)
        {
            healthComp.HP += 10;
        }

        protected override void Use()
        {
            
        }
    }
}
