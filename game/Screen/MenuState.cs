using game.Backgrounds;
using LevelDesign.LevelDesign;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace game.Screen
{
    public class MenuState : State
    {
        List<screen> screen;
        public MenuState(Game1 game, GraphicsDevice graphics, ContentManager content) : base(game, graphics, content)
        {
            var Buttont = content.Load<Texture2D>("button");
            var buttonf = content.Load<SpriteFont>("Font");

            var button1 = new knop(Buttont, buttonf)
            {
                pos = new Vector2(300, 200),
                displaytext = "Nieuw spel",
                
            };

            button1.clicker += NEWGameButton_Click;

            var button2 = new knop(Buttont, buttonf)
            {
                pos = new Vector2(300, 250),
                displaytext = "Laad spel",
            };

            button2.clicker += LOADGameButton_Click;

            var buttonQ = new knop(Buttont, buttonf)
            {
                pos = new Vector2(300, 300),
                displaytext = "Exit",
            };

            buttonQ.clicker += STOP_CLICK;

            screen = new List<screen>()
            {
                button1,
                button2,
                buttonQ,
            };
        }
        public override void Draw(GameTime gameTime, SpriteBatch sprite, Background bg1, Background bg2, Camera camera, Speler hero, Level level)
        {
            sprite.Begin();
            foreach(var screen in screen)
            {
                screen.Draw(gameTime, sprite);
            }
            sprite.End();
        }

        public override void Update(GameTime gameTime)
        {
            foreach(var screen in screen)
            {
                screen.Update(gameTime);
            }
        }
        public void STOP_CLICK(object sender, EventArgs e)
        {
            gamee.Exit();
        }
        public void LOADGameButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Laad het spel");
        }
        public void NEWGameButton_Click(object sender, EventArgs e)
        {
            gamee.state(new Gamestate(gamee, graphicsDevice, content));
        }
    }
}
