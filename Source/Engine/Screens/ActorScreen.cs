using System;
using System.Collections.Generic;
using System.Text;
using SadConsole;
using SadConsole.Input;
using Microsoft.Xna.Framework;
using Console = SadConsole.Console;

namespace SimpleSpaceRogue.Source.Engine.Screens
{
    class ActorScreen : ContainerConsole
    {
        public Console ActorConsole { get; set; }
        public List<Actor> actorList { get; set; }
        public Actor player { get; set; }

        public MapScreen mapScreen { get; }

        static void Init()
        {
            Global.CurrentScreen = new ActorScreen();
        }

        public ActorScreen()
        {
            var actorConsoleWidth = (int)((Global.RenderWidth / Global.FontDefault.Size.X) * 1.0f);
            var actorConsoleHeight = (int)((Global.RenderHeight / Global.FontDefault.Size.Y) * 1.0f);
            actorList = new List<Actor>();
            ActorConsole = new Console(actorConsoleWidth, actorConsoleHeight);
            mapScreen = new MapScreen();
            ActorConsole.Parent = this;
            player = new Actor(1, 1, Color.Orange, Color.Transparent, '@');
            actorList.Add(player);

            foreach (Actor act in actorList)
            {
                ActorConsole.Children.Add(act);
            }

        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            Point newPlayerPos = player.Position;

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.W))
            {
                if (newPlayerPos.Y >= 0 && newPlayerPos.Y != 0)
                {
                    newPlayerPos += SadConsole.Directions.North;

                }
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.A))
            {
                if (newPlayerPos.X >= 0 && newPlayerPos.X != 0)
                {
                    newPlayerPos += SadConsole.Directions.West;
                }

            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.S))
            {
                if (newPlayerPos.Y <= mapScreen.mapConsole.Height - 2 && newPlayerPos.Y != mapScreen.mapConsole.Height)
                {
                    newPlayerPos += SadConsole.Directions.South;
                }
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D))
            {
                if (newPlayerPos.X <= mapScreen.mapConsole.Width - 2 && newPlayerPos.X != mapScreen.mapConsole.Width)
                {
                    newPlayerPos += SadConsole.Directions.East;

                }
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Q))
            {
                newPlayerPos += SadConsole.Directions.NorthWest;
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.E))
            {
                newPlayerPos += SadConsole.Directions.NorthEast;
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Z))
            {
                newPlayerPos += SadConsole.Directions.SouthWest;
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.C))
            {
                newPlayerPos += SadConsole.Directions.SouthEast;
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
