using System;
using System.Collections.Generic;
using System.Text;
using SadConsole.Components;
using SadConsole.Input;
using Microsoft.Xna.Framework;
using SimpleSpaceRogue.Source.Engine.Actors;
using SimpleSpaceRogue.Source.Engine.Screens;
using SimpleSpaceRogue.Source.Consoles;
using SimpleSpaceRogue.Source.Engine;

namespace SimpleSpaceRogue
{
    /// <summary>
    /// A component that allows control of an actor (Moving, attacking, etc.)
    /// </summary>
    class KeyboardComponent : KeyboardConsoleComponent
    {
        private Actor _actor;

        private MapScreen _mapScreen;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actor"> The Actor to be controlled</param>
        /// <param name="mapScreen">The parent MapScreen</param>
        public KeyboardComponent(Actor actor, ref MapScreen mapScreen)
        {
            this._actor = actor;
            this._mapScreen = mapScreen;
        }

        public override void ProcessKeyboard(SadConsole.Console console, Keyboard info, out bool handled)
        {
            handled = true;
            HandleInput(info);
        }

        /// <summary>
        /// Processes input for the controlled Actor
        /// </summary>
        /// <returns></returns>
        private bool HandleInput(Keyboard info)
       {

           if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.W))
           {
                _actor.Position += SadConsole.Directions.North;
                _mapScreen.mapConsole.UpdateFOV();
           }

           if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.A))
           {
                _actor.Position += SadConsole.Directions.West;
                _mapScreen.mapConsole.UpdateFOV();
           }

           if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.S))
           {
                _actor.Position += SadConsole.Directions.South;
                _mapScreen.mapConsole.UpdateFOV();
           }

           if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D))
           {
                _actor.Position += SadConsole.Directions.East;
                _mapScreen.mapConsole.UpdateFOV();
           }

           if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Q))
           {
                _actor.Position += SadConsole.Directions.NorthWest;
                _mapScreen.mapConsole.UpdateFOV();
           }

           if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.E))
           {
                _actor.Position += SadConsole.Directions.NorthEast;
                _mapScreen.mapConsole.UpdateFOV();
           }

           if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Z))
           {
                _actor.Position += SadConsole.Directions.SouthWest;
                _mapScreen.mapConsole.UpdateFOV();
           }

           if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.C))
           {
                _actor.Position += SadConsole.Directions.SouthEast;
                _mapScreen.mapConsole.UpdateFOV();
           }

           if (_actor.Position != _actor.Position)
           {
               _actor.Position = _actor.Position;
               return true;
           }
           return false;

       }

        /// <summary>
        /// Used to take control of an Actor
        /// </summary>
        /// <param name="actor">The Actor to be controlled</param>
        public void Possess(ref Actor actor)
        {
            if (actor == null)
            {
                Console.WriteLine("No valid actor found!");
                return;
            }
            else 
            {
                _actor = actor;
                Console.WriteLine("You have taken control of %s", actor.Name.ToString());
            }
        }

    }

    
}
