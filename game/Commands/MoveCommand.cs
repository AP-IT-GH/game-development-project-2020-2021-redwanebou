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
        public Vector2 snelheid { get; set; }
        public bool spring { get; set; }
        private int grenswaarde = 1595;

        public void Execute(GameTime gameTime, ITransform transform, Vector2 richting, SoundEffect jump)
        {
            if (richting.X == 1 || richting.X == -1)
            {
                // snelheid beweging //
                richting *= new Vector2(5,0);
                transform.positie += richting;
            }
            // Go up //
            transform.positie += snelheid;
            if (richting.Y == -1 && !spring)
            {
                transform.positie = new Vector2(transform.positie.X, transform.positie.Y - 10f);
                snelheid = new Vector2(0, -5f);
                jump.Play();
                spring = true;
            }
            if (spring)
            {
                // hoe snel gaan we down //
                snelheid += new Vector2(0, 0.15f);
            }
            else
            {
                snelheid = new Vector2(0, 0);
            }

            if (transform.positie.Y > grenswaarde)
            {
                spring = false;
            }
        }
    }
}
