using System;
using System.Collections.Generic;
using System.Text;
using SadConsole;
using SadConsole.Input;
using Microsoft.Xna.Framework;
using SimpleSpaceRogue.Source.Engine.Tiles;
using Console = SadConsole.Console;

namespace SimpleSpaceRogue.Source.Engine
{
    class MapScreen : ContainerConsole
    {
        public Console mapConsole { get; }
        public List<TileBase> tileList { get; set; }
    
        static void Init()
        {
            Global.CurrentScreen = new MapScreen();
        }

        public MapScreen()
        {
            var mapConsoleWidth = (int)((Global.RenderWidth / Global.FontDefault.Size.X) * 1.0f);
            var mapConsoleHeight = (int)((Global.RenderHeight / Global.FontDefault.Size.Y) * 1.0f);
            mapConsole = new Console(mapConsoleWidth, mapConsoleHeight);
            tileList = new List<TileBase>();
            for (int i = 0; i <= mapConsole.Width; i++)
            {
                tileList.Add(new TileFloor(i, i, '.'));
            }
            //mapConsole.SetSurface(tileList.ToArray(), 1, 1);
            mapConsole.Parent = this;
            
        }

  
    }
}

