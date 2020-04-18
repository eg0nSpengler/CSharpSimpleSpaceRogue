using System;
using SadConsole;
using SadConsole.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Console = SadConsole.Console;
using SimpleSpaceRogue.Source.Engine;
using SimpleSpaceRogue.Source.Consoles;
using SimpleSpaceRogue.Source.Engine.Screens;

namespace SimpleSpaceRogue
{
    class Program
    {
        private const int _screenWidth = 80;
        private const int _screenHeight = 25;
        private static Microsoft.Xna.Framework.GameTime _gameTime;
        private static Console _rootConsole;
        private static MapScreen _mapScreen;
        private static ActorScreen _actorScreen;


        static void Main(string[] args)
        
        {
            SadConsole.Game.Create(_screenWidth, _screenHeight);

            SadConsole.Game.OnInitialize = GameInit;

            SadConsole.Game.OnUpdate = GameUpdate;
             
            SadConsole.Game.OnDraw = GameDraw;

            SadConsole.Game.OnDestroy = GameDestroy;

            SadConsole.Game.Instance.Run();
        }

        static void GameInit()
        {
            _rootConsole = new Console(_screenWidth, _screenHeight);
            _actorScreen = new ActorScreen();
            _mapScreen = new MapScreen();
            _gameTime = new GameTime(new TimeSpan(), new TimeSpan());
            _rootConsole.Children.Add(_mapScreen);
            _rootConsole.Children.Add(_actorScreen);
            SadConsole.Global.FocusedConsoles.Push(_actorScreen.actorConsole);
            SadConsole.Global.CurrentScreen = _rootConsole; 
        }

        static void GameUpdate(GameTime gameTime)
        {
            _mapScreen.mapConsole.Update(_gameTime.ElapsedGameTime);
        }

        static void GameDestroy()
        {
            System.Console.WriteLine("Game instance destroyed!");
        }

        static void GameDraw(GameTime gameTime)
        {
            
        }

    }
}
