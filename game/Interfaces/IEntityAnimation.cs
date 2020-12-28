using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace game.Animation
{
    public interface IEntityAnimation
    {
         Animatie Animatie { get; set; }

         void Draw(SpriteBatch spriteBatch, SpriteEffects sprite);
        void Update(GameTime gameTime);
        
        
    }
}
