using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using game.Interfaces;

namespace game.world
{
    public class Blok: ICollision
    {
        public Texture2D _texture { get; set; }
        public Vector2 Positie { get; set; }
        public Rectangle CollisionRectangle { get ; set ; }

        public Blok(Texture2D texture, Vector2 pos)
        {
            _texture = texture;
            Positie = pos;
            CollisionRectangle = new Rectangle((int)Positie.X, (int)Positie.Y, 128, 64);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Positie, Color.AliceBlue);
        }

        public void Update()
        {

        }
    }
}
