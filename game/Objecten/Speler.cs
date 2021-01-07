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
using Microsoft.Xna.Framework.Audio;

namespace game
{
    public class Speler : ITransform, ICollision
    {

        //  private Animatie animatie;
        // een lijn instellen //
        public Vector2 positie { get; set; }

        public Rectangle CollisionRectangle { get; set; }
        private Rectangle _collisionRectangle;

        Collisionn colli;

        private IInputReader inputReader;

        private IGameCommand Movecommand;

        public SpriteEffects sprite;

        IEntityAnimation walk;


        public Speler(Texture2D texture, IInputReader reader, List<Rectangle> blokken)
        {
            walk = new WalkAnimation(texture, this);

          //  move = new MoveCommand();

            // stel een basispositie in //
           positie = new Vector2(0, 305);

            // Read input for my hero class
            this.inputReader = reader;

            Movecommand = new MoveCommand();

            // WAAR IS ONZE HERO ? RECTANGLE IS HET LAATSTE 2 height && breedte //
            _collisionRectangle = new Rectangle((int)positie.X, (int)positie.Y, 55, 80);

            colli = new Collisionn(this, blokken);

        }

        public void Update(GameTime gameTime,SoundEffect spring)
        {

            int screenx = 1014;
            int screeny = 600;
            var richting = inputReader.LeesInput();


            MoveMyHero(richting,gameTime, spring);

            walk.Update(gameTime);

            _collisionRectangle.X = (int)positie.X;
            _collisionRectangle.Y = (int)positie.Y;
            CollisionRectangle = _collisionRectangle;

            colli.Update(gameTime, CollisionRectangle, screenx, screeny, Movecommand, richting);

        }


        private void MoveMyHero(Vector2 richting, GameTime gameTime, SoundEffect spring)
        {
            if (richting.X == -1)
            {
                sprite = SpriteEffects.FlipHorizontally;
            }
           if (richting.X == 1)
            {
                sprite = SpriteEffects.None;
            }
            if (richting.Y == -1 && richting.X == -1)
            {
                sprite = SpriteEffects.FlipHorizontally;
            }
            if (richting.Y == -1 && richting.X == 1)
            {
                sprite = SpriteEffects.None;
            }
            Movecommand.Execute(gameTime, this, richting, spring);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
         walk.Draw(spriteBatch, sprite);
      }
    }
}
