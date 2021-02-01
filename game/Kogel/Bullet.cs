using game.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace game.kogel
{
    public class Bullet : Kogel
    {
        float _timer;
        private Vector2 collibullet;

        public override void Update(GameTime gameTime, List<Kogel> sprites, SpriteEffects effect, ITransform trans)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer >= LifeSpan)
                IsRemoved = true;

            collibullet = Position += Direction * LinearVelocity;
            // add to collision //
            enemybullet = new Rectangle((int)collibullet.X, (int)collibullet.Y, 5, 5);
        }
    }
}
