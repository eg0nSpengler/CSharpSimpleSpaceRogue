using System;
using System.Collections.Generic;
using System.Text;
using SadConsole.Entities;
using SadConsole.Components;
using GoRogue.GameFramework;
using Microsoft.Xna.Framework;
using GoRogue;

namespace SimpleSpaceRogue.Source.Engine
{
    /// <summary>
    /// A base entity which has a Position, Glyph, and Color
    /// </summary>
    public class Actor :  Entity, IGameObject
    {

        private IGameObject _gameObject;

        /// <summary>
        /// The glyph used to represent the Actor
        /// </summary>
        public int Glyph { get; }

        public Map CurrentMap => _gameObject.CurrentMap;

        public bool IsStatic { get; set; }

        public bool IsTransparent { get => _gameObject.IsTransparent; set => _gameObject.IsTransparent = value; }
        public bool IsWalkable { get => _gameObject.IsWalkable; set => _gameObject.IsWalkable = value; }

        Coord IGameObject.Position { get => _gameObject.Position; set => _gameObject.Position = value; }

        public Coord coord { get; set; }

        public uint ID => _gameObject.ID;

        public int Layer => _gameObject.Layer;

        /// <summary>
        /// A base entity which has a Position, Glyph, and Color
        /// </summary>
        /// <param name="x">X Position</param>
        /// <param name="y">Y Position</param>
        /// <param name="foreground">Actor Foreground Color</param>
        /// <param name="background">Actor Background Color</param>
        /// <param name="glyph">The glyph to represent the Actor</param>
        public Actor(int x, int y, Color foreground, Color background, int glyph) : base(foreground, background, glyph)
        {
            this.coord = new Coord(x, y);
            this.DefaultForeground = foreground;
            this.DefaultBackground = background;
            this.Glyph = glyph;
            _gameObject = new GameObject(this.coord, 0, parentObject: this, isStatic: true, false, false);
        }

        /// <summary>
        /// A base entity which has a Position, Glyph, and Color
        /// </summary>
        /// <param name="x">X Position</param>
        /// <param name="y">Y Position</param>
        /// <param name="glyph">The glyph to represent the Actor</param>
        public Actor(int x, int y, int glyph) : base(1, 1)
        {
            this.coord = new Coord(x, y);
            this.Glyph = glyph;
            _gameObject = new GameObject(this.coord, 0, parentObject: this, isStatic: true, false, false);
        }

        /// <summary>
        /// A base entity which has a Position, Glyph, and Color
        /// </summary>
        /// <param name="x">X Position</param>
        /// <param name="y">Y Position</param>
        /// <param name="foreground">Actor Foreground Color</param>
        /// <param name="glyph">The glyph to represent the Actor</param>
        public Actor(int x, int y, Color foreground, int glyph) : base(foreground, Color.Transparent, glyph)
        {
            this.coord = new Coord(x, y);
            this.DefaultForeground = foreground;
            this.Glyph = glyph;
            _gameObject = new GameObject(this.coord, 0, parentObject: this, isStatic: true, false, false);
        }

        /// <summary>
        /// A base entity which has a Position, Glyph, and Color
        /// </summary>
        /// <param name="x">X Position</param>
        /// <param name="y">Y Position</param>
        public Actor(int x, int y) : base(1, 1)
        {
            this.coord = new Coord(x, y);
            _gameObject = new GameObject(this.coord, 0, parentObject: this, isStatic: true, false, false);
        }

        event EventHandler<ItemMovedEventArgs<IGameObject>> IGameObject.Moved
        {

            add
            {
                _gameObject.Moved += value;
            }

            remove
            {
                _gameObject.Moved -= value;
            }
        }

        public bool MoveIn(Direction direction)
        {
            System.Console.WriteLine(coord.ToString());
            return _gameObject.MoveIn(direction);
        }

        public void OnMapChanged(Map newMap)
        {
            _gameObject.OnMapChanged(newMap);
        }

        public void AddComponent(object component)
        {
            _gameObject.AddComponent(component);
        }

        IConsoleComponent IHasComponents.GetComponent<IConsoleComponent>()
        {
            return _gameObject.GetComponent<IConsoleComponent>();
        }

        IEnumerable<IConsoleComponent> IHasComponents.GetComponents<IConsoleComponent>()
        {
            return _gameObject.GetComponents<IConsoleComponent>();
        }

        public bool HasComponent(Type componentType)
        {
            return _gameObject.HasComponent(componentType);
        }

        public bool HasComponent<T>()
        {
            return _gameObject.HasComponent<T>();
        }

        public bool HasComponents(params Type[] componentTypes)
        {
            return _gameObject.HasComponents(componentTypes);
        }

        public void RemoveComponent(object component)
        {
            _gameObject.RemoveComponent(component);
        }

        public void RemoveComponents(params object[] components)
        {
            _gameObject.RemoveComponents(components);
        }

    }
}
