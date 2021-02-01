using game.Input;
using game.kogel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace game.Animation
{
    public class Animatie
    {
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> frameB = new List<AnimationFrame>();
        private List<AnimationFrame> frameM = new List<AnimationFrame>();
        private List<AnimationFrame> frameS = new List<AnimationFrame>();
        private IInputReader input = new Toetsenbord();
        int counter;
        double frameMovement;

        public void WalkM(GameTime gameTime)
        {
            CurrentFrame = frameM[counter];

            frameMovement += CurrentFrame.SourceRectangle.Width * gameTime.ElapsedGameTime.TotalSeconds;

            if (frameMovement >= CurrentFrame.SourceRectangle.Width / 6)
            {
                counter++;
                frameMovement = 0;
            }

            if (counter >= frameM.Count)
                counter = 0;
        }

        public void Update(GameTime gameTime)
        {
            if (input.LeesInput().X != -1 || input.LeesInput().X != 1)
            {
                frameB.Add((new AnimationFrame(new Rectangle(0, -4, 80, 94))));
                CurrentFrame = frameB[0];
            }

            if (input.LeesInput().X == 1 || input.LeesInput().X == -1)
            {
                for(int jj = 0; jj <= 400; jj += 80)
                {
                    frameM.Add(new AnimationFrame(new Rectangle(jj, 94, 80, 94)));
                }
                WalkM(gameTime);
            }

            if (input.LeesInput().Y == 1)
            {
                frameS.Add(new AnimationFrame(new Rectangle(0, 276, 80, 94)));
                CurrentFrame = frameS[0];
            }
        }

    }
}
