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

namespace game
{
    public class Hero : ITransform, ICollision
    {
        private Texture2D herotexture;

        private Animatie animatie;
        // een lijn instellen //
        public Vector2 positie { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        private Rectangle _collisionRectangle;

        private IInputReader inputReader;
        private IInputReader mouseReader;


        private IGameCommand moveCommand;

        private IGameCommand moveToCommand;

        IEntityAnimation walkRight, walkLeft, currentAnimation;


        // default constructor //
        public Hero(Texture2D texture, IInputReader reader)
        {
            herotexture = texture;
            walkRight = new WalkRightAnimation(texture, this);
            walkLeft = new WalkLeftAnimation(texture, this);
            currentAnimation = walkRight;
           // animatie = new Animatie();
            // je begint altijd bij 0 //
           // animatie.AddFrame(new Animationframe(new Rectangle(0, 0, 64, 96)));
           // animatie.AddFrame(new Animationframe(new Rectangle(128, 0, 64, 96)));
          //  animatie.AddFrame(new Animationframe(new Rectangle(192, 0, 64, 96)));
           // animatie.AddFrame(new Animationframe(new Rectangle(256, 0, 64, 96)));
          //  animatie.AddFrame(new Animationframe(new Rectangle(320, 0, 64, 96)));
          //  animatie.AddFrame(new Animationframe(new Rectangle(384, 0, 64, 96)));
           // animatie.AddFrame(new Animationframe(new Rectangle(448, 0, 64, 96)));
          //  positie = new Vector2(10, 10);

            // Read input for my hero class
            this.inputReader = reader;

            mouseReader = new Muis();

            moveCommand = new MoveCommand();
            moveToCommand = new MoveToCommand();

            _collisionRectangle = new Rectangle((int)positie.X, (int)positie.Y, 280, 385);

        }

        public void Update(GameTime gameTime)
        {

            var richting = inputReader.LeesInput();
            MoveHorizontal(richting);

            if (inputReader.ReadFollower())
                // vind muispositie //
                Move(mouseReader.LeesInput());


            // wanneer ik op letter M druk volg ik de muis //
            // animatie.Update(gameTime);

            currentAnimation.Update(gameTime);

            _collisionRectangle.X = (int)positie.X;
            CollisionRectangle = _collisionRectangle;
        }

        private void MoveHorizontal(Vector2 richting)
        {
            if (richting.X == -1)
                currentAnimation = walkLeft;
            else if (richting.X == 1)
                currentAnimation = walkRight;

            moveCommand.Execute(this, richting);
        }

        private void Move(Vector2 mouse)
        {

            moveToCommand.Execute(this, mouse);
         
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            currentAnimation.Draw(spriteBatch);

            // aanroepen && positie update steeds //
            // spriteBatch.Draw(herotexture, positie, animatie.Huidigeframe.sourceregtangle, Color.White);
        }
    }
}
