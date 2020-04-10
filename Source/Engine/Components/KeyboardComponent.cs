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

            Point newPlayerPos = _actor.Position;

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.W))
           {
                if (!_mapScreen.mapConsole.IsWall(newPlayerPos.X, newPlayerPos.Y - 1))
                   {
                       newPlayerPos += SadConsole.Directions.North;
                       _mapScreen.mapConsole.UpdateFOV();

                    }
           }

           if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.A))
           {
                if (!_mapScreen.mapConsole.IsWall(newPlayerPos.X - 1, newPlayerPos.Y))
                {
                        newPlayerPos += SadConsole.Directions.West;
                        _mapScreen.mapConsole.UpdateFOV();
                }
           }

           if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.S))
           {

                if (!_mapScreen.mapConsole.IsWall(newPlayerPos.X, newPlayerPos.Y + 1))
                {
                        newPlayerPos += SadConsole.Directions.South;
                        _mapScreen.mapConsole.UpdateFOV();
                }
           }

           if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D))
           {
                   if (!_mapScreen.mapConsole.IsWall(newPlayerPos.X + 1, newPlayerPos.Y))
                   {
                        newPlayerPos += SadConsole.Directions.East;
                        _mapScreen.mapConsole.UpdateFOV();
                   }
           }

           if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Q))
           {
                    if (!_mapScreen.mapConsole.IsWall(newPlayerPos.X - 1, newPlayerPos.Y - 1))
                    {
                        newPlayerPos += SadConsole.Directions.NorthWest; 
                        _mapScreen.mapConsole.UpdateFOV();
                    }
           }

           if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.E))
           {
                if (!_mapScreen.mapConsole.IsWall(newPlayerPos.X + 1, newPlayerPos.Y - 1))
                {
                        newPlayerPos += SadConsole.Directions.NorthEast;
                        _mapScreen.mapConsole.UpdateFOV();
                }
           }

           if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Z))
           {
                if (!_mapScreen.mapConsole.IsWall(newPlayerPos.X - 1, newPlayerPos.Y + 1))
                {
                        newPlayerPos += SadConsole.Directions.SouthWest;
                        _mapScreen.mapConsole.UpdateFOV();
                }
           }

           if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.C))
           {
                    if (!_mapScreen.mapConsole.IsWall(newPlayerPos.X + 1, newPlayerPos.Y + 1))
                    {
                        newPlayerPos += SadConsole.Directions.SouthEast;    
                        _mapScreen.mapConsole.UpdateFOV();
                    }
           }

           if (newPlayerPos != _actor.Position)
           {
               _actor.Position = newPlayerPos;
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
