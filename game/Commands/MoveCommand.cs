using game.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace game.Commands
{

  public class MoveCommand:IGameCommand
    {
        // DEZE CLASS IS VOOR TOETSENBORD MOVE //
        public Vector2 snelheid;
        public Vector2 snelheidUp;
        bool check;

        public MoveCommand()
        {
            this.snelheid = new Vector2(5, 0);
        }
        public void Execute(ITransform transform, Vector2 richting)
        {
            if (richting.X == 1 || richting.X == -1)
            {
                // hoe beweeg ik ?
                richting *= snelheid;
                transform.positie += richting;
            }

            // Go up //
            transform.positie += snelheidUp;

            if (richting.Y == -1 && check == false)
            {
                transform.positie = new Vector2(transform.positie.X, transform.positie.Y - 10f);
                snelheidUp.Y = -5f;
                check = true;
            }
            if (check == true)
            {
                // hoe snel gaan we down //
                float jj = 1;
                snelheidUp.Y += 0.15f * jj;
            }else
            {
                snelheidUp.Y = 0f;
            }

            if (transform.positie.Y > 300)
            {
                check = false;
            }
        }
    }
}
