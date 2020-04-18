using System;
using System.Collections.Generic;
using System.Text;
using SimpleSpaceRogue.Source.Engine;
using SimpleSpaceRogue.Source.Engine.Actors;
using SadConsole;
using SadConsole.Input;
using Microsoft.Xna.Framework;

namespace SimpleSpaceRogue.Source.Consoles
{
    /// <summary>
    /// The Actor Console contains all the logic for the construction/deconstruction, rendering, and handling of all Actors
    /// </summary>
    public class ActorConsole : SadConsole.Console
    {
        private static int _actorConsoleWidth = (int)((Global.RenderWidth / Global.FontDefault.Size.X) * 1.0f);
        private static int _actorConsoleHeight = (int)((Global.RenderHeight / Global.FontDefault.Size.Y) * 1.0f);

        public static Player _player;
        private static List<Actor> _actorList;
        private static MapScreen _mapScreen;
        private static KeyboardComponent _kbComponent;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent">The Screen that this console will be parented to</param>
        public ActorConsole(SadConsole.Console parent) : base(_actorConsoleWidth, _actorConsoleHeight)
        {
            _actorList = new List<Actor>();
            _player = new Player(1, 1);
            _mapScreen = new MapScreen();
            _kbComponent = new KeyboardComponent(_player, ref _mapScreen);

            this.Components.Add(_kbComponent);
            _actorList.Add(_player);

            foreach (Actor act in _actorList)
            {
                this.Children.Add(act);
            }

            this.Parent = parent;
        }

        public override void Update(TimeSpan timeElapsed)
        {
            
        }

    }
}
