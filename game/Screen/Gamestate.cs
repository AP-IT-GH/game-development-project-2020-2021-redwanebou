using game.Backgrounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using LevelDesign.LevelDesign;
using System.Text;

namespace game.Screen
{
    class Gamestate : State
    {
        public Gamestate(Game1 game, GraphicsDevice graphics, ContentManager content) : base(game, graphics, content) {}
        public override void Draw(GameTime gameTime, SpriteBatch sprite, Background bg1, Background bg2, Camera camera, Speler hero, Level level)
        {
            sprite.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Mat);
            bg1.Draw(sprite);
            bg2.Draw(sprite);
            hero.Draw(sprite);
            level.DrawWorld(sprite);
            sprite.End();
        }

        public override void Update(GameTime gameTime){ }
    }
}
