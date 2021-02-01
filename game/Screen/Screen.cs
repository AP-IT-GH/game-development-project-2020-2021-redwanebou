using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace game
{
   public abstract class screen
    {
        public abstract void Draw(GameTime gameTime, SpriteBatch sprite);

        public abstract void Update(GameTime gameTime);
    }
}
