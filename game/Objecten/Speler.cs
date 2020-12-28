using game.Animation;
using game.Commands;
using game.Input;
using game.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using game.Animation.HeroAnimations;
using System.Diagnostics;

namespace game
{
    public class Speler : ITransform, ICollision
    {

        //  private Animatie animatie;
        // een lijn instellen //
        public Vector2 positie { get; set; }

        public Rectangle CollisionRectangle { get; set; }
        private Rectangle _collisionRectangle;

        private IInputReader inputReader;
 
        private IGameCommand moveCommand;

        public SpriteEffects sprite;

        IEntityAnimation walk;


        // default constructor //
        public Speler(Texture2D texture, IInputReader reader)
        {
            walk = new WalkAnimation(texture, this);

            // stel een basispositie in //
            positie = new Vector2(0, 305);

            // Read input for my hero class
            this.inputReader = reader;


            moveCommand = new MoveCommand();

            // WAAR IS ONZE HERO ? RECTANGLE IS HET LAATSTE 2 height && breedte //
            _collisionRectangle = new Rectangle((int)positie.X, (int)positie.Y, 64, 96);
        }

        public void Update(GameTime gameTime)
        {
            var richting = inputReader.LeesInput();

            MoveMyHero(richting);

            walk.Update(gameTime);

            _collisionRectangle.X = (int)positie.X;
            _collisionRectangle.Y = (int)positie.Y;
            CollisionRectangle = _collisionRectangle;

        }


        private void MoveMyHero(Vector2 richting)
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

            moveCommand.Execute(this, richting);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

         walk.Draw(spriteBatch, sprite);
    }
    }
}
