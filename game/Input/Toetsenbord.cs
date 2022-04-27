using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace game.Input
{
   class Toetsenbord : IInputReader
    {
        public Vector2 LeesInput()
        {
            var richting = Vector2.Zero;

            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Left))
                richting = new Vector2(-1, 0);

            if (state.IsKeyDown(Keys.Right))
                richting = new Vector2(1, 0);

            if (state.IsKeyDown(Keys.Up))
                richting = new Vector2(0, -1);

            if (state.IsKeyDown(Keys.Space))
                richting = new Vector2(0, 1);

            return richting;
        }
    }
}
