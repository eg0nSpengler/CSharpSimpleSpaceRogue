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
            Global.CurrentScreen = new MapScreen();
        }

        public MapScreen()
        {
            var mapConsoleWidth = (int)((Global.RenderWidth / Global.FontDefault.Size.X) * 1.0f);
            var mapConsoleHeight = (int)((Global.RenderHeight / Global.FontDefault.Size.Y) * 1.0f);
            mapConsole = new MapConsole(mapConsoleWidth, mapConsoleHeight);
            for (int x = 0; x <= mapConsole.Width; x++)
            {
                for (int y = 0; y <= mapConsole.Height; y++)
                {
                    mapConsole.tileList.Add(new TileFloor(x, y, '.', Color.LightGreen));
                }
            }
            mapConsole.tileList.Add(new TileWall(5, 5, 'X', Color.Pink));
            mapConsole.tileList.Add(new TileWall(5, 6, 'X', Color.Pink));
            mapConsole.tileList.Add(new TileWall(5, 7, 'X', Color.Pink));
            mapConsole.tileList.Add(new TileWall(5, 8, 'X', Color.Pink));

            foreach (TileBase tile in mapConsole.tileList)
            {
                mapConsole.SetGlyph(tile.x, tile.y, tile.glyph, tile.foreColor);
            }

            mapConsole.Parent = this;
            
        }
  
    }
}

