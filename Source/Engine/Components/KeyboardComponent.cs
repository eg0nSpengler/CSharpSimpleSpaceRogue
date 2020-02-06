using System;
using System.Collections.Generic;
using System.Text;
using SadConsole.Components;
using SadConsole.Input;
using Microsoft.Xna.Framework;
using SimpleSpaceRogue.Source.Engine.Actors;
using SimpleSpaceRogue.Source.Engine.Screens;
using SimpleSpaceRogue.Source.Engine;

namespace SimpleSpaceRogue
{
    class KeyboardComponent : KeyboardConsoleComponent
    {
        private Player player;

        private MapScreen mapScreen;

        public KeyboardComponent(Player player, ref MapScreen mapScreen)
        {
            this.player = player;
            this.mapScreen = mapScreen;
        }

        public override void ProcessKeyboard(SadConsole.Console console, Keyboard info, out bool handled)
        {
            handled = true;
            HandleInput(info);
        }
        public bool HandleInput(Keyboard info)
       {
           Point newPlayerPos = player.Position;
            
           if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.W))
           {
               if (newPlayerPos.Y >= 0 && newPlayerPos.Y != 0)
               {
                   if (!mapScreen.mapConsole.IsWall(newPlayerPos.X, newPlayerPos.Y - 1))
                   {
                       newPlayerPos += SadConsole.Directions.North;
                   }
               }
           }

           if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.A))
           {
               if (newPlayerPos.X >= 0 && newPlayerPos.X != 0)
               {
                   if (!mapScreen.mapConsole.IsWall(newPlayerPos.X - 1, newPlayerPos.Y))
                   {
                       newPlayerPos += SadConsole.Directions.West;
                   }
               }

           }

           if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.S))
           {
               if (newPlayerPos.Y <= mapScreen.mapConsole.Height - 2 && newPlayerPos.Y != mapScreen.mapConsole.Height)
               {
                   if (!mapScreen.mapConsole.IsWall(newPlayerPos.X, newPlayerPos.Y + 1))
                   {
                       newPlayerPos += SadConsole.Directions.South;
                   }


               }
           }

           if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D))
           {
               if (newPlayerPos.X <= mapScreen.mapConsole.Width - 2 && newPlayerPos.X != mapScreen.mapConsole.Width)
               {
                   if (!mapScreen.mapConsole.IsWall(newPlayerPos.X + 1, newPlayerPos.Y))
                   {
                       newPlayerPos += SadConsole.Directions.East;
                   }

               }
           }

           if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Q))
           {
                    if (!mapScreen.mapConsole.IsWall(newPlayerPos.X - 1, newPlayerPos.Y - 1))
                    {
                       newPlayerPos += SadConsole.Directions.NorthWest; 
                    }
           }

           if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.E))
           {
                if (!mapScreen.mapConsole.IsWall(newPlayerPos.X + 1, newPlayerPos.Y - 1))
                {
                    newPlayerPos += SadConsole.Directions.NorthEast;
                }
           }

           if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Z))
           {
                if (!mapScreen.mapConsole.IsWall(newPlayerPos.X - 1, newPlayerPos.Y + 1))
                {
                    newPlayerPos += SadConsole.Directions.SouthWest;
                }
           }

           if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.C))
           {
                if (newPlayerPos.X + 1 <= mapScreen.mapConsole.Width && newPlayerPos.Y + 1 != mapScreen.mapConsole.Height)
                {
                    if (!mapScreen.mapConsole.IsWall(newPlayerPos.X + 1, newPlayerPos.Y + 1))
                    {
                        newPlayerPos += SadConsole.Directions.SouthEast;    
                    }
                }
           }

           if (newPlayerPos != player.Position)
           {
               player.Position = newPlayerPos;
               return true;
           }
           return false;

       }

    }
}
