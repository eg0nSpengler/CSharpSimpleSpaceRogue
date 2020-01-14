using System;
using System.Collections.Generic;
using System.Text;
using SimpleSpaceRogue.Source.Engine.Actors;
using SimpleSpaceRogue.Source.Engine.Actors.Items;
using SadConsole;
using SadConsole.Input;
using Microsoft.Xna.Framework;
using Console = SadConsole.Console;

namespace SimpleSpaceRogue.Source.Engine.Screens
{
    class ActorScreen : ContainerConsole
    {
        public Console ActorConsole;

        public List<Actor> actorList;

        public Player player;

        public MapScreen mapScreen;

        public KeyboardComponent kbComponent;

        public HealPatchItem healPatch;

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
            player = new Player(1, 1, Color.Orange, Color.Transparent, '@');
            healPatch = new HealPatchItem(10, 5, Color.Red, '!');
            kbComponent = new KeyboardComponent(player, ref mapScreen);
            actorList.Add(healPatch);
            actorList.Add(player);
            ActorConsole.Parent = this;
            ActorConsole.Components.Add(kbComponent);
            foreach (Actor act in actorList)
            {
                ActorConsole.Children.Add(act);
            }

        }

        public Actor GetItem(int x, int y)
        {
            foreach (Actor item in actorList)
            {
                if (item.x == x && item.y == y)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
