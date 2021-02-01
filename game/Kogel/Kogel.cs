using game.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using game.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace game.kogel
{
    public class Kogel
    {
        /* BRONVERMELDING: https://www.youtube.com/watch?v=G7xSWcmnC0c&t=910s&ab_channel=Oyyou */

        public Vector2 Position;

        public Vector2 Direction;

        public float LinearVelocity;

        public Kogel Parent;

        public float LifeSpan;

        public bool IsRemoved;

        public Rectangle enemybullet;

        public virtual void Update(GameTime gameTime, List<Kogel> sprites, SpriteEffects effects, ITransform trans) {}

        public virtual void Draw(SpriteBatch spriteBatch,Texture2D _texture)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
