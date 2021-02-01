using game.Animation;
using game.Commands;
using game.Input;
using game.Interfaces;
using game.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using game.Animation.HeroAnimations;
using System.Diagnostics;
using Microsoft.Xna.Framework.Content;
using LevelDesign.LevelDesign;
using game.kogel;
using Microsoft.Xna.Framework.Audio;

namespace game
{
    public class Speler : ITransform, ICollision
    {
        public Vector2 positie { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        public List<Kogel> kogels;
        private Rectangle _collisionRectangle;
        private Collisionn colli;
        private IInputReader inputReader = new Toetsenbord();
        private IGameCommand Movecommand = new MoveCommand();
        private IEntityAnimation walk;
        private Texture2D kogel;

        public Speler(Texture2D texture, List<Rectangle> blokken,ContentManager content)
        {
            // basis pos //
            positie = new Vector2(70, 1595);
            walk = new WalkAnimation(texture, this);
            // Read input for my hero class
            _collisionRectangle = new Rectangle((int)positie.X, (int)positie.Y, 66, 86);
            colli = new Collisionn(this, blokken);
            kogels = new List<Kogel>()
            {
            new ShootCommand()
            {
            Bullet = new Bullet(),
            },
            };
            InitializeContent(content);
        }

        private void InitializeContent(ContentManager content)
        {
            kogel = content.Load<Texture2D>("kogel");
        }

        public void Update(GameTime gameTime,SoundEffect spring)
         {
            walk.Update(gameTime);

            Movecommand.Execute(gameTime, this, inputReader.LeesInput(), spring);

            _collisionRectangle.X = (int)positie.X;
            _collisionRectangle.Y = (int)positie.Y;
            CollisionRectangle = _collisionRectangle;

            colli.Update(gameTime, CollisionRectangle, 1798, Movecommand);

            foreach (var sprite in kogels.ToArray())
                sprite.Update(gameTime, kogels, walk.sprite, this);

            DeleteBullet();
        }

        public void DeleteBullet()
        {
            for (int i = 0; i < kogels.Count; i++)
            {
                if (kogels[i].IsRemoved)
                {
                    kogels.RemoveAt(i);
                    i--;
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
         walk.Draw(spriteBatch);
         foreach (var sprite in kogels)
         if (sprite.LinearVelocity != 0)
         sprite.Draw(spriteBatch, kogel);
        }
    }
}
