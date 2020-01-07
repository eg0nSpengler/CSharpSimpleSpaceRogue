using System;
using System.Collections.Generic;
using System.Text;
using SadConsole.Components;
using SadConsole.Input;
using Microsoft.Xna.Framework;
using SimpleSpaceRogue.Source.Engine;

namespace SimpleSpaceRogue
{
    class KeyboardComponent : KeyboardConsoleComponent
    {
        public override void ProcessKeyboard(SadConsole.Console console, Keyboard info, out bool handled)
        {
            handled = true;
            if (info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Space))
            {
                console.DefaultBackground = Color.White.GetRandomColor(SadConsole.Global.Random);
                console.Clear();
            }
        }

    }
}
