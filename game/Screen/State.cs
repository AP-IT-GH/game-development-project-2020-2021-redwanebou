using LevelDesign.LevelDesign;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace game.Screen
{
    public abstract class State
    {
        /* BRONVERMELDING: https://www.youtube.com/watch?v=76Mz7ClJLoE&ab_channel=Oyyou */
        public Game1 gamee;

        public ContentManager content;

        public GraphicsDevice graphicsDevice;

        public State(Game1 game, GraphicsDevice graphics, ContentManager content)
        {
            this.gamee = game;

            this.graphicsDevice = graphics;

            this.content = content;
        }

        public abstract void Draw(GameTime gameTime, SpriteBatch sprite);

        public abstract void Update(GameTime gameTime);

    }
}
