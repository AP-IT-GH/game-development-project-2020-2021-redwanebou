using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace game.Backgrounds
{
   public class Background
    {
        public Texture2D texture;
        public Rectangle rectangle;

        public Background(Texture2D newTexture, Rectangle newRectangle)
        {
            texture = newTexture;
            rectangle = newRectangle;
        }
        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(texture, rectangle, Color.White);
        }

        public void Update()
        {
            rectangle.X -= 2;
        }

        public void CheckTheBg(Rectangle bg1, Rectangle bg2)
        {
            if (bg1.X + bg1.Width < 0)
            {
                bg1.X = bg2.X + bg2.Width;
            }
            if (bg2.X + bg1.Width < 0)
            {
                bg2.X = bg2.X + bg2.Width;
            }

        }
    }
}
