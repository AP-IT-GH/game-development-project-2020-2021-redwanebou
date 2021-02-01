using game.Commands;
using game.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using game.Input;
namespace game.Collision
{
    class Collisionn
    {
        private List<Rectangle> detectedblokken;
        private IInputReader input = new Toetsenbord();
        private ITransform trans;

        public Collisionn(ITransform transform, List<Rectangle> blokken)
        {
            this.trans = transform;
            this.detectedblokken = blokken;
        }

        public void Update(GameTime gameTime, Rectangle hero, int x, IGameCommand moveCommand)
        {
            if (trans.positie.X < 0)
                trans.positie = new Vector2(0, hero.Y);

            if (trans.positie.X > x - hero.Width)
                trans.positie = new Vector2(x - hero.Width, hero.Y);

            foreach (Rectangle blok in detectedblokken)
            {
                if (VanBoven(hero, blok))
                {
                    moveCommand.snelheid = Vector2.Zero;
                    moveCommand.spring = false;
                }

                // hero mag nooit onder de grond gaan //
                if (trans.positie.Y > 1595)
                {
                   trans.positie = new Vector2(trans.positie.X, 1595);
                }
                if (!VanBoven(hero, blok) && trans.positie.Y < 1595 && input.LeesInput().X == 1 && !CheckCollision(hero,blok) ||
                     !VanBoven(hero, blok) && trans.positie.Y < 1595 && input.LeesInput().X == -1 && !CheckCollision(hero, blok))
                {
                   moveCommand.spring = true;
                }
                if (VanLinks(hero, blok) && input.LeesInput().X == 1)
                {
                    if (input.LeesInput().X == -1)
                    {
                        break;
                    }
                    trans.positie = new Vector2(blok.X - hero.Width - 2, hero.Y);
                }
                if (VanRechts(hero, blok) && input.LeesInput().X == -1)
                {
                    if (input.LeesInput().X == 1)
                    {
                        break;
                    }
                    trans.positie = new Vector2(blok.X + blok.Width + 2, hero.Y);
                }
                // ervoor zorgen dat die niet door de blok kan //
                if (VanOnder(hero, blok) && input.LeesInput().Y == -1)
                    moveCommand.snelheid = new Vector2(0, -2.5f);
            }
        }


        public bool CheckCollision(Rectangle rect1, Rectangle rect2)
        {
            if (rect1.Intersects(rect2))
                return true;

            return false;
        }

        /* BRONVERMELDING: https://www.youtube.com/watch?v=CV8P9aq2gQo&t=432s&ab_channel=Oyyou */
        public bool VanBoven(Rectangle hero, Rectangle blok)
        {
            return (hero.Bottom >= blok.Top - 5 &&
                 hero.Bottom <= blok.Top + 1 &&
                 hero.Right >= blok.Left + 5 &&
                 hero.Left <= blok.Right - 5) ;
        }

        public bool VanOnder(Rectangle hero, Rectangle blok)
        {
            return (hero.Top <= blok.Bottom + (blok.Height / 5) &&
                            hero.Top >= blok.Bottom - 1 &&
                            hero.Right >= blok.Left + (blok.Width / 5) &&
                            hero.Left <= blok.Right - (blok.Width / 2));
        }

        public bool VanLinks(Rectangle hero, Rectangle blok)
        {
            return (hero.Right <= blok.Right &&
                hero.Right >= blok.Left - 5 &&
                hero.Top <= blok.Bottom - (blok.Width / 4) &&
                hero.Bottom >= blok.Top + (blok.Width / 4));
        }

        public bool VanRechts(Rectangle hero, Rectangle blok)
        {
            return (hero.Left >= blok.Left &&
                hero.Left <= blok.Right + 5 &&
                hero.Top <= blok.Bottom - (blok.Width / 4) &&
                hero.Bottom >= blok.Top + (blok.Width / 4));
        }
    }
}
