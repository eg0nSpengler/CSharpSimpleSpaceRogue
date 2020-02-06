using System;
using System.Collections.Generic;
using System.Text;
using SadConsole;
using Microsoft.Xna.Framework;
using SimpleSpaceRogue.Source.Engine;
using SimpleSpaceRogue.Source.Engine.Tiles;

namespace SimpleSpaceRogue.Source.Consoles
{
    public class MapConsole : SadConsole.Console
    {
        /// <summary>
        /// A list of tiles for the entire map
        /// </summary>
        public List<TileBase> tileList;

        public MapConsole(int width, int height) : base(width, height)
        {
            Width = width;
            Height = height;
            var mapConsoleWidth = (int)((width / Global.FontDefault.Size.X) * 1.0f);
            var mapConsoleHeight = (int)((height / Global.FontDefault.Size.Y) * 1.0f);
            tileList = new List<TileBase>();
            FillMap();
        }

        public bool IsWall(int x, int y)
        {
            foreach (TileBase tile in tileList)
            {
                if (tile.x == x && tile.y == y && tile.IsWalkable == false)
                {
                    System.Console.WriteLine("It's a wall!");
                    return true;
                }
            }
                return false;
        }

        public void FillMap()
        {
            for (int x = 0; x <= this.Width; x++)
            {
                for (int y = 0; y <= this.Height; y++)
                {
                    tileList.Add(new TileFloor(x, y, '.', Color.LightGreen));
                }
            }

            for (int x = 0; x <= Width; x++)
            {
                for (int y = 0; y <= Height; y++)
                {
                    tileList.Add(new TileWall(x, y, 'X', Color.Pink));
                }
            }

            foreach (TileBase tile in tileList)
            {
                SetGlyph(tile.x, tile.y, tile.glyph, tile.foreColor);
            }
        }
       
    }
}
