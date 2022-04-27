using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace game.Screen
{
    class knop : screen
    {
        /* BRONVERMELDING: https://www.youtube.com/watch?v=76Mz7ClJLoE&ab_channel=Oyyou */
        private SpriteFont FontSize;
        private MouseState muisnu;
        private MouseState muisoud;
        private bool hover;
        private Texture2D texture;
        public Vector2 pos { get; set; }
        public event EventHandler clicker;
        public Color pcolor { get; set; }
        public string displaytext { get; set; }

        public knop(Texture2D texture, SpriteFont FontSize)
        {
            this.texture = texture;
            this.FontSize = FontSize;
            pcolor = Color.Black;
        }

        public Rectangle positietext
        {
            get
            {
                return new Rectangle((int)pos.X, (int)pos.Y, texture.Width, texture.Height);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch sprite)
        {
            var color = Color.White;

            if (hover)
                color = Color.Gray;

            sprite.Draw(texture, positietext, color);

            if (displaytext != "")
            {
                var x = (positietext.X + (positietext.Width) / 2) - (FontSize.MeasureString(displaytext).X / 2);
                var y = (positietext.Y + (positietext.Height / 2)) - (FontSize.MeasureString(displaytext).Y / 2);
                sprite.DrawString(FontSize, displaytext, new Vector2(x, y), pcolor);
            }
        }

        public override void Update(GameTime gameTime)
        {
            muisoud = muisnu;
            muisnu = Mouse.GetState();

            var mRectangle = new Rectangle(muisnu.X, muisnu.Y, 1, 1);

            hover = false;

            if (mRectangle.Intersects(positietext))
            {
                hover = true;
                if (muisnu.LeftButton == ButtonState.Released && muisoud.LeftButton == ButtonState.Pressed)
                    clicker?.Invoke(this, new EventArgs());
            }

        }
    }
}
