using System;
using System.Collections.Generic;
using System.Text;
using SadConsole;
using GoRogue.MapViews;
using GoRogue.MapGeneration;
using GoRogue.GameFramework;
using GoRogue;
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
        public static List<Tile> tileList;

        private static ArrayMap<bool> _terrainMap;

        private static Map _gameMap;

        /// <summary>
        /// A list of tiles within the FOV
        /// </summary>
        private static FOV _fovMap;

        /// <summary>
        /// A list of previous coordinates for tiles that were within the FOV
        /// </summary>
        private static List<Coord> _prevFOVPos;

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
            tileList = new List<Tile>();
            _terrainMap = new ArrayMap<bool>(width, height);
            _gameMap = new Map(width: _terrainMap.Width, height: _terrainMap.Height, numberOfEntityLayers: 1, distanceMeasurement: Distance.CHEBYSHEV);
            _fovMap = new FOV(_terrainMap);
            _prevFOVPos = new List<Coord>();
            CreateRooms();
            RenderMap();
            UpdateFOV();
            this.Parent = parent;
        }

        public void SetProperties(int x, int y, bool isTransparent, bool isWalkable)
        {
            var index = tileList.FindIndex(tile => tile.Position.X == x && tile.Position.Y == y);
            tileList[index].IsTransparent = isTransparent;
            tileList[index].IsWalkable = isWalkable;
        }

        public void FillMap()
        {
            for (int x = 0; x <= SadConsole.Global.CurrentScreen.Width; x++)
            {
                for (int y = 0; y <= SadConsole.Global.CurrentScreen.Height; y++)
                {
                    tileList.Add(new Tile(x, y));
                }
            }
        }

        public void CreateRooms()
        {
            QuickGenerators.GenerateRandomRoomsMap(_terrainMap, 12, 4, 12);

            foreach (var pos in _terrainMap.Positions())
            {
                if (_terrainMap[pos])
                {

                    _gameMap.SetTerrain(new TileFloor(pos.X, pos.Y));
                    ActorConsole._player.Position = new Point(pos.X, pos.Y);
                    _gameMap.AddEntity(ActorConsole._player);
                }
                else
                {
                    _gameMap.SetTerrain(new TileWall(pos.X, pos.Y));
                }
            }

            foreach (var tile in _gameMap.Positions())
            {
                var walkable = _gameMap.WalkabilityView[tile.X, tile.Y].ToString();
                
                SetGlyph(tile.X, tile.Y, walkable.ToBool() ? '.' : 'x');
            }

        }
  
 
        public void BuildFOV(int x, int y, int radius)
        {
            _fovMap.Calculate(x, y, radius);
        }

        public void UpdateFOV()
        {
            this.BuildFOV(ActorConsole._player.Position.X, ActorConsole._player.Position.Y, 5); 
        }

        public bool IsInFov(int x, int y) 
        {
            if (_fovMap.BooleanFOV[x, y] == true)
            {
                _gameMap.Explored[x, y] = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsExplored(int x, int y)
        {
            return _gameMap.Explored[x, y];
        }

        public void RenderMap()
        {
            foreach (var tile in _gameMap.Positions())
            {
                var walkable = _gameMap.WalkabilityView[tile.X, tile.Y].ToString();

                if (IsInFov(tile.X, tile.Y) == true)
                {
                    SetForeground(tile.X, tile.Y, walkable.ToBool() ? Color.LightGreen : Color.LightGray);
                }
                else if (IsExplored(tile.X, tile.Y) == true)
                {
                    SetForeground(tile.X, tile.Y, walkable.ToBool() ? Color.DarkGreen : Color.DarkGray);
                }
                else
                {
                    SetForeground(tile.X, tile.Y, Color.Black);
                }


            } 
            
        }

        public void RenderFOV()
        {
          
            foreach(var tile in _gameMap.Positions())
            {
                if (IsInFov(tile.X, tile.Y) == false)
                {
                    SetBackground(tile.X, tile.Y, Color.DarkGray);   
                }

            }

        }
        protected override void OnDirtyChanged()
        {
            System.Console.WriteLine("MapConsole is dirty!");
        }

        public override void Update(TimeSpan timeElapsed)
        {
            RenderMap();
        }
    }
}
