using game.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace game.Commands
{

  public class MoveCommand:IGameCommand
    {
        // DEZE CLASS IS VOOR TOETSENBORD MOVE //
        public Vector2 snelheid;

        public MoveCommand()
        {
            this.snelheid = new Vector2(5, 0);
        }
        public void Execute(ITransform transform, Vector2 richting)
        {
            richting *= snelheid;
            transform.positie += richting;
        }
    }
}
