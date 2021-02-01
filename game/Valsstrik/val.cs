using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace game.Valsstrik
{
    class val
    {
        private List<Rectangle> collivals = new List<Rectangle>();
        private Texture2D vall;
        private int count;

        public val(Texture2D val)
        {
            this.vall = val;
        }
        public bool Gestorven(Rectangle hero)
        {
            foreach(Rectangle check in collivals)
            if (check.Intersects(hero))
                return true;

            return false;
        }
        public void CreateVal()
        {
            for (int jj = 0; count < 26; jj += 70)
            {
                count++;
                if (jj == 0 || jj >= 210)
                collivals.Add(new Rectangle(jj, 1595 + 52, 35, 70));
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(var item in collivals)
            spriteBatch.Draw(vall, new Vector2(item.X, 1595 + 52), Color.White);
        }
    }
}
