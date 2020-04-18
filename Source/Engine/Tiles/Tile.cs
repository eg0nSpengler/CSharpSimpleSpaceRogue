using System;
using System.Collections.Generic;
using System.Text;
using SadConsole;
using Microsoft.Xna.Framework;
using GoRogue.GameFramework;
using GoRogue;

namespace SimpleSpaceRogue.Source.Engine.Tiles
{
    /// <summary>
    /// A base tile
    /// </summary>
    public class Tile : Cell, IGameObject
    {

        private IGameObject _gameObject;

        public Point Position { get; set; }

        public Map CurrentMap => _gameObject.CurrentMap;

        public bool IsStatic => _gameObject.IsStatic;

        Coord IGameObject.Position { get => _gameObject.Position; set => _gameObject.Position = value; }

        public uint ID => _gameObject.ID;

        public int Layer => _gameObject.Layer;

        public bool IsTransparent { get => _gameObject.IsTransparent; set => _gameObject.IsTransparent = value; }
        public bool IsWalkable { get => _gameObject.IsWalkable; set => _gameObject.IsWalkable = value; }

        public Tile(int x, int y, int glyph)
        {
            this.Position = new Point(x, y);
            this.Glyph = glyph;
            _gameObject = new GameObject(this.Position, 0, parentObject: this, isStatic: true, false, false);
           
        }

        public Tile(int x, int y, int glyph, Color foregroundColor)
        {
            this.Position = new Point(x, y);
            this.Glyph = glyph;
            this.Foreground = foregroundColor;
            _gameObject = new GameObject(this.Position, 0, parentObject: this, isStatic: true, false, false);
        }

        public Tile(int x, int y)
        {
            this.Position = new Point(x, y);
            _gameObject = new GameObject(this.Position, 0, parentObject: this, isStatic: true, false, false);
        }

        public event EventHandler<ItemMovedEventArgs<IGameObject>> Moved
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

        public T GetComponent<T>()
        {
            return _gameObject.GetComponent<T>();
        }

        public IEnumerable<T> GetComponents<T>()
        {
            return _gameObject.GetComponents<T>();
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
