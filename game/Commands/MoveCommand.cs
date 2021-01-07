using game.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace game.Commands
{

  public class MoveCommand:IGameCommand
    {
        // DEZE CLASS IS VOOR TOETSENBORD MOVE //
        public Vector2 snelheid { get; set; }
        public bool spring { get; set; }

        public void Execute(GameTime gameTime, ITransform transform, Vector2 richting, SoundEffect jump)
        {
            if (richting.X == 1 || richting.X == -1)
            {
                // hoe beweeg ik ?
                richting *= new Vector2(5,0);
                transform.positie += richting;
            }
            // Go up //
            transform.positie += snelheid;
            if (richting.Y == -1 && spring == false)
            {
                transform.positie = new Vector2(transform.positie.X, transform.positie.Y - 10f);

                snelheid = new Vector2(0, -5f);

                jump.Play();

                spring = true;
            }
            if (spring == true)
            {
                // hoe snel gaan we down //
                float jj = 1;

                snelheid += new Vector2(0, 0.15f * jj);
            }
            else
            {
                snelheid = new Vector2(0, 0);
            }

            if (transform.positie.Y > 300)
            {
                spring = false;
            }
        }
    }
}
