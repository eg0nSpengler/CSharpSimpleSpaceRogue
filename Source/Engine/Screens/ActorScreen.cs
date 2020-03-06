using System;
using System.Collections.Generic;
using System.Text;
using SimpleSpaceRogue.Source.Engine.Actors;
using SimpleSpaceRogue.Source.Engine.Actors.Items;
using SimpleSpaceRogue.Source.Consoles;
using SadConsole;
using SadConsole.Input;
using Microsoft.Xna.Framework;
using Console = SadConsole.Console;

namespace SimpleSpaceRogue.Source.Engine.Screens
{
    /// <summary>
    /// The ActorScreen serves as a Parent object for all actor-related consoles to bind to
    /// </summary>
    public class ActorScreen : ContainerConsole
    {
        public ActorConsole actorConsole;

        /*public List<Actor> actorList;

        public Player player;

        public MapScreen mapScreen;

        public KeyboardComponent kbComponent;

        public HealPatchItem healPatch;*/

        static void Init()
        {
            Global.CurrentScreen = new ActorScreen();
        }

        public ActorScreen()
        {
            actorConsole = new ActorConsole(this);
        }
       

    }
}
