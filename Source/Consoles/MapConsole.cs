using System;
using System.Collections.Generic;
using System.Text;
using SadConsole;
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
            tileList = new List<TileBase>();
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

       
    }
}
