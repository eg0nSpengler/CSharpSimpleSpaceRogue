using System;
using System.Collections.Generic;
using System.Text;
using SadConsole;
using GoRogue.MapViews;
using Microsoft.Xna.Framework;
using SimpleSpaceRogue.Source.Engine;
using SimpleSpaceRogue.Source.Engine.Tiles;

namespace SimpleSpaceRogue.Source.Consoles
{
    /// <summary>
    /// The Map Console contains all the logic for the construction/deconstruction, rendering, and handling of the currently loaded map
    /// </summary>
    public class MapConsole : SadConsole.Console
    {
        /// <summary>
        /// A list of tiles for the entire map
        /// </summary>
        /// 
        public static List<TileBase> tileList;

        public static List<Ray> rays = new List<Ray>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width">The width of the map</param>
        /// <param name="height">The height of the map</param>
        /// <param name="parent">The Screen that this console will be parented to</param>
        public MapConsole(int width, int height, SadConsole.Console parent) : base(width, height)
        {
            Width = width;
            Height = height;
            tileList = new List<TileBase>();
            FillMap();
            CreateRooms();
            RenderMap();
            this.Parent = parent;
        }

        public bool IsWalkable(int x, int y)
        {
            foreach (TileBase tile in tileList)
            {
                if (tile == null)
                {
                    return false;
                }

                else if (tile.Position.X == x && tile.Position.Y == y && tile.IsWalkable == true)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsWall(int x, int y)
        {
            return !IsWalkable(x, y);
        }

        public void SetProperties(int x, int y, bool isTransparent, bool isWalkable)
        {
            var index = tileList.FindIndex(tile => tile.Position.X == x && tile.Position.Y == y);
            tileList[index].IsTransparent = isTransparent;
            tileList[index].IsWalkable = isWalkable;
        }

        public void FillMap()
        {
            for(int x = 0; x <= SadConsole.Global.CurrentScreen.Width; x++)
            {
                for (int y = 0; y <= SadConsole.Global.CurrentScreen.Height; y++)
                {
                    tileList.Add(new TileBase(x, y));
                }
            }
        }

        public void CreateRooms()
        {
            var rect = CreateRect(1, 1, 4, 4);
            RectangleExtensions2.ToConsole(rect, SadConsole.Global.FontDefault);
            var rectArea = rect.Width * rect.Height;
            var index = tileList.FindIndex(tile => tile.Position.X == rect.X && tile.Position.Y == rect.Y);

            for (int x = 0; x <= 12; x++)
            {
                for (int y = 0; y <= 12; y++)
                {
                    SetProperties(x, y, true, true);
                }
            }

            SetProperties(4, 4, false, false);
            SetProperties(4, 5, false, false);
            SetProperties(4, 6, false, false);
            SetProperties(4, 7, false, false);
            SetProperties(4, 8, false, false);
        }

        public void BuildFOV()
        {
        
        }

        public static void UpdateFOV(float x, float y, int radius)
        {
            List<Ray> rays = new List<Ray>();

            for (int i = 0; i <= 360; i += 10)
            {
                rays.Add(new Ray(new Vector3(x, y, 1.0f), new Vector3(i)));
            }

        }

        public void RenderMap()
        {
            foreach (TileBase tile in tileList)
            {
                this.SetGlyph(tile.Position.X, tile.Position.Y, IsWall(tile.Position.X, tile.Position.Y) ? 'X' : '.', IsWall(tile.Position.X, tile.Position.Y) ? Color.LightCoral : Color.LightGreen);
            }
            
        }

        /// <summary>
        /// Returns a newly constructed Rectangle converted to Cell coordinates
        /// </summary>
        /// <param name="x">X Position/param>
        /// <param name="y">Y Position</param>
        /// <param name="width">Rectangle width</param>
        /// <param name="height">Rectangle height</param>
        public Rectangle CreateRect(int x, int y, int width, int height)
        {
            return new Rectangle(x, y, width, height);
        }
    }
}
