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
    class MapScreen : ContainerConsole
    {
        public MapConsole mapConsole;

        static void Init()
        {

        }

        public MapScreen()
        {
            mapConsole = new MapConsole(640, 480);
            mapConsole.Parent = this;
        }

    }
}

