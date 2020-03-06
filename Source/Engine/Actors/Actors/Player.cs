using System;
using System.Collections.Generic;
using System.Text;
using SimpleSpaceRogue.Source.Engine.Components;
using Microsoft.Xna.Framework;

namespace SimpleSpaceRogue.Source.Engine.Actors
{
    /// <summary>
    /// A controllable actor that serves as the Player Character
    /// </summary>
    class Player : Actor
    {
        public Player(int x, int y) : base(x, y, Color.Pink, '@')
        {
            System.Console.WriteLine("Player created!");
        }

    }
}
