using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using game.Interfaces;

namespace game.Animation.HeroAnimations
{
    public class WalkLeftAnimation: IEntityAnimation
    {
        private Animatie _animatie;
        Texture2D texture;
        ITransform transform;

        public WalkLeftAnimation(Texture2D texture, ITransform transform)
        {
            this.transform = transform;
            this.texture = texture;           
            _animatie = new Animatie();
            _animatie.AddFrame(new AnimationFrame(new Rectangle(0, 0, 64, 96)));
           _animatie.AddFrame(new AnimationFrame(new Rectangle(128, 0, 64, 96)));
          _animatie.AddFrame(new AnimationFrame(new Rectangle(192, 0, 64, 96)));
            _animatie.AddFrame(new AnimationFrame(new Rectangle(256, 0, 64, 96)));
          _animatie.AddFrame(new AnimationFrame(new Rectangle(320, 0, 64, 96)));
          _animatie.AddFrame(new AnimationFrame(new Rectangle(384, 0, 64, 96)));
           _animatie.AddFrame(new AnimationFrame(new Rectangle(448, 0, 64, 96)));
       
        }

        public Animatie Animatie
        {
            get { return _animatie; }
            set { _animatie = value; }
        }
       

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, transform.positie, _animatie.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.FlipHorizontally, 0);
        }

        public void Update(GameTime gameTime)
        {
            _animatie.Update(gameTime);
        }
    }
}
