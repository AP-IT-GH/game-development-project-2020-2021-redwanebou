using game.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace game.Animation.HeroAnimations
{
    class WalkAnimation:IEntityAnimation
    {
        private Animatie _animatie;
        private Texture2D texture;
        private ITransform transform;

        public WalkAnimation(Texture2D texture, ITransform transform)
        {
            this.texture = texture;
            this.transform = transform;
            _animatie = new Animatie();
            for (int jj = 0; jj != 448; jj+=64)
            {
                _animatie.AddFrame(new AnimationFrame(new Rectangle(jj, 0, 64, 96)));
            }
        }

        public Animatie Animatie
        {
            get { return _animatie; }
            set { _animatie = value; }
        }

        public Texture2D Texture { get; set; }

        public void Draw(SpriteBatch spriteBatch, SpriteEffects sprite)
        {
            spriteBatch.Draw(texture, transform.positie, _animatie.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 1f, sprite, 0);
        }

        public void Update(GameTime gameTime)
        {
            _animatie.Update(gameTime);
        }
    }
}
