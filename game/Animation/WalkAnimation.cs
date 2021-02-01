using game.Input;
using game.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace game.Animation.HeroAnimations
{
    class WalkAnimation : IEntityAnimation,ITransform
    {
        private Animatie _animatie = new Animatie();
        private IInputReader input = new Toetsenbord();
        private Texture2D texture;
        private ITransform transform;
        public Vector2 positie { get; set; }
        public SpriteEffects sprite { get; set; }

        public WalkAnimation(Texture2D texture, ITransform transform)
        {
            this.texture = texture;
            this.transform = transform;
        }

        public void Update(GameTime gameTime)
        {
            ChangeDirection(gameTime);
             _animatie.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, transform.positie, _animatie.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 1f, sprite, 0);
        }

        public void ChangeDirection(GameTime gameTime)
        {
            if (input.LeesInput().X == -1)
                sprite = SpriteEffects.FlipHorizontally;

            if (input.LeesInput().X == 1)
                sprite = SpriteEffects.None;

            if (input.LeesInput().Y == -1 && input.LeesInput().X == -1)
                sprite = SpriteEffects.FlipHorizontally;

            if (input.LeesInput().Y == -1 && input.LeesInput().X == 1)
                sprite = SpriteEffects.None;
        }
    }
}
