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
            // begin positie //
            var richting = Vector2.Zero;

            // toetsen uitlezen van toetsenbord //
            KeyboardState state = Keyboard.GetState();


            // IsKeyDown = is er een toets ingedrukt ? Zo ja check of het Links is 
            if (state.IsKeyDown(Keys.Left))
            {
                richting = new Vector2(-1, 0);
            }

            if (state.IsKeyDown(Keys.Right))
            {
                richting = new Vector2(1, 0);
            }

            if (state.IsKeyDown(Keys.Space))
            {
                richting = new Vector2(0, -1);
            }

            return richting;
        }
    }
}
