using System;
using System.Collections.Generic;
using System.Text;
using SadConsole;
using SadConsole.Input;
using Microsoft.Xna.Framework;
using SimpleSpaceRogue.Source.Engine.Tiles;
using SimpleSpaceRogue.Source.Consoles;
using Console = SadConsole.Console;

namespace SimpleSpaceRogue.Source.Engine
{
    /// <summary>
    /// The MapScreen serves as a Parent object for all map-related consoles to bind to
    /// </summary>
    class MapScreen : ContainerConsole
    {
        public MapConsole mapConsole;

        static void Init()
        {
            
        }

        public MapScreen()
        {
            mapConsole = new MapConsole(SadConsole.Global.CurrentScreen.Width, SadConsole.Global.CurrentScreen.Height, this);
        }

        public override void Update(TimeSpan timeElapsed)
        {
            mapConsole.Update(timeElapsed);
        }

    }
}

