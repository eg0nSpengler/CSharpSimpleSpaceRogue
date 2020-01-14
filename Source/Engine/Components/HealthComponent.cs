using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSpaceRogue.Source.Engine.Components
{
    public class HealthComponent
    {
       public int HP { get; set; }

        public HealthComponent(int hitPoints)
        {
            this.HP = hitPoints;
        }
    }
}
