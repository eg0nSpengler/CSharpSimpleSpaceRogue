using System;
using SadConsole;
using SadConsole.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Console = SadConsole.Console;
using SimpleSpaceRogue.Source.Engine;
using SimpleSpaceRogue.Source.Engine.Screens;

namespace SimpleSpaceRogue
{
    class Program
    {
        public static int screenWidth = 80;
        public static int screenHeight = 25;
        public static Console rootConsole;
        public static MapScreen mapScreen;
        public static ActorScreen actorScreen; 
        static void Main(string[] args)
        {
            SadConsole.Game.Create(screenWidth, screenHeight);

            SadConsole.Game.OnInitialize = GameInit;

            SadConsole.Game.Instance.Run();

            SadConsole.Game.Instance.Dispose();
        }

        static void GameInit()
        {
            rootConsole = new Console(screenWidth, screenHeight);
            mapScreen = new MapScreen();
            actorScreen = new ActorScreen();
            rootConsole.Children.Add(mapScreen);
            rootConsole.Children.Add(actorScreen);
            SadConsole.Global.FocusedConsoles.Push(actorScreen.ActorConsole);
            SadConsole.Global.CurrentScreen = rootConsole;


        }
    }
}
