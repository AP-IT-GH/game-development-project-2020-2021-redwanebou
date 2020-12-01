using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace game.Animation
{
    class Animatie
    {
        public Animationframe Huidigeframe { get; set; }
        private List<Animationframe> frame;

        private int counter;

        private double frameMovement = 0;

        public Animatie()
        {
            frame = new List<Animationframe>();

        }

        public void AddFrame(Animationframe animationFrame)
        {
            frame.Add(animationFrame);
            Huidigeframe = frame[0];
        }
        public void Update(GameTime gameTime)
        {
            Huidigeframe = frame[counter];
            // omzetten naar frame per seconde //
            frameMovement += Huidigeframe.sourceregtangle.Width * gameTime.ElapsedGameTime.TotalSeconds;

            // hoe snel moet die lopen ? //
            if (frameMovement >=Huidigeframe.sourceregtangle.Width/10)
            {
                counter++;
                frameMovement = 0;
            }

            if (counter >= frame.Count)
            {
                counter = 0;
            }
        }
    }
}
