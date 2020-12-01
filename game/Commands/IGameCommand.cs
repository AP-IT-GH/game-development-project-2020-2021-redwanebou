using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using game.Interfaces;

namespace game.Commands
{
   public interface IGameCommand
    {
        void Execute(ITransform transform, Vector2 richting);
    }
}
