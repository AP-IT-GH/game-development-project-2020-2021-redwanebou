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

namespace game
{
    public class Hero : ITransform
    {
        Texture2D herotexture;
        Animatie animatie;

        private Vector2 snelheid;
        private Vector2 versnelling;
        // een lijn instellen //
        public Vector2 positie { get; set; }
        private  IInputReader inputReader;
        private IInputReader mouseReader;


        private IGameCommand moveCommand;

        private IGameCommand moveToCommand;

        // default constructor //
        public Hero(Texture2D texture, IInputReader reader)
        {
            herotexture = texture;
            animatie = new Animatie();
            // je begint altijd bij 0 //
            animatie.AddFrame(new Animationframe(new Rectangle(0, 0, 64, 96)));
            animatie.AddFrame(new Animationframe(new Rectangle(128, 0, 64, 96)));
            animatie.AddFrame(new Animationframe(new Rectangle(192, 0, 64, 96)));
            animatie.AddFrame(new Animationframe(new Rectangle(256, 0, 64, 96)));
            animatie.AddFrame(new Animationframe(new Rectangle(320, 0, 64, 96)));
            animatie.AddFrame(new Animationframe(new Rectangle(384, 0, 64, 96)));
            animatie.AddFrame(new Animationframe(new Rectangle(448, 0, 64, 96)));
          //  positie = new Vector2(10, 10);
            // v //
            snelheid = new Vector2(1, 1);
            // versnelling //
            versnelling = new Vector2(0.1f, 0.1f);

            // Read input for my hero class
            this.inputReader = reader;

            mouseReader = new Muis();

            moveCommand = new MoveCommand();
            moveToCommand = new MoveToCommand();
         }

        public void Update(GameTime gameTime)
        {

            var richting = inputReader.LeesInput();
            MoveHorizontal(richting);

            if (inputReader.ReadFollower())
                // vind muispositie //
                Move(mouseReader.LeesInput());


            // wanneer ik op letter M druk volg ik de muis //
            animatie.Update(gameTime);
        }

        private void MoveHorizontal(Vector2 richting)
        {
            moveCommand.Execute(this, richting);
        }

        private void Move(Vector2 mouse)
        {

            moveToCommand.Execute(this, mouse);
         
            // een limiet instellen op x en y //
            // een vector bestaat uit X en Y //
           // if (positie.X > 600 || positie.X < 0)
          //  {
                // hij draait op deze manier terug //
          //      snelheid.X *= -1;
           //  versnelling.X *= -1;
           // }
           // if (positie.Y > 400 || positie.Y < 0)
           // {
           //     snelheid.Y *= -1;
           //     versnelling *= -1;
           // }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            // aanroepen && positie update steeds //
            spriteBatch.Draw(herotexture, positie, animatie.Huidigeframe.sourceregtangle, Color.White);
        }
    }
}
