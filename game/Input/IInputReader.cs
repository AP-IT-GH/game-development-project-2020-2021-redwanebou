using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace game.Input
{
    public interface IInputReader
    {
        // iedereen die deze interface toevoegd gaat input lezen //
        Vector2 LeesInput();

        bool ReadFollower();
    }
}
