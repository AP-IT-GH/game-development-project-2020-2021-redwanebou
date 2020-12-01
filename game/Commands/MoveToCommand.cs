using game.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace game.Commands
{
    class MoveToCommand : IGameCommand
    {
        private Vector2 snelheid;
        public MoveToCommand()
        {
            snelheid = new Vector2(1, 0);
        }

        // DEZE CLASS IS VOOR MUIS VOLGEN //
        public void Execute(ITransform transform, Vector2 richting)
        {
            // richting vinden //
            richting = Vector2.Add(richting, -transform.positie);
            // blijf in de buurt van de muis en trip niet //
            richting.Normalize();
             richting = Vector2.Multiply(richting, 0.5f);

             snelheid += richting;
            // 5 is de maximum versnelling, hij mag niet sneller gaan //
              snelheid = Limiet(snelheid, 5);
            transform.positie += snelheid;
        }
        // methode om snelheid versnelling limiet te behouden //
        private Vector2 Limiet(Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }
    }

}
