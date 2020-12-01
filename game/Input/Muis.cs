using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace game.Input
{
    public class Muis : IInputReader
    {
        public bool ReadFollower()
        {
            throw new NotImplementedException();
        }
        public Vector2 LeesInput()
        {
            MouseState state = Mouse.GetState();
            var mouseVector = new Vector2(state.X, state.Y);
            return mouseVector;
        }

    }
}
