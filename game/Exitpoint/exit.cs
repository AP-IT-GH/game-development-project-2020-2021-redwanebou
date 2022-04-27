using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace game.Valsstrik
{
    class exit
    {
        public Rectangle colliexit;
        private Texture2D exitt;
        private Vector2 positie;

        public exit(Texture2D exit,bool check)
        {
            this.exitt = exit;
            WhichLevel(check);
        }
        public void WhichLevel(bool check)
        {
           if (!check) {
                // level 1 positie //
                colliexit = new Rectangle(5, 1345, 55, 56);
                positie = new Vector2(5, 1345);
            }else
            {
                positie = new Vector2(285, 1275);
                colliexit = new Rectangle(285, 1275, 55, 56);
            }
        }
        public bool CheckNextLevel(Rectangle hero)
        {
                if (colliexit.Intersects(hero))
                    return true;

            return false;
        }
        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(exitt, positie, Color.White);
        }
    }
}
