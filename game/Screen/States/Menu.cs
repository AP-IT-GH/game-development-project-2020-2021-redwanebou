using game.Valsstrik;
using LevelDesign.LevelDesign;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace game.Screen
{
    public class Menu : State
    {
        /* BRONVERMELDING: https://www.youtube.com/watch?v=76Mz7ClJLoE&ab_channel=Oyyou */
        private List<screen> screen;
        private Texture2D buttont,beginbg,buttong;
        private SpriteFont buttonf;
        public Menu(Game1 game, GraphicsDevice graphics, ContentManager content, bool nextlevel) : base(game, graphics, content)
        {
            InitializeContent();
            ButtonDraw(nextlevel);
        }
        private void InitializeContent()
        {
            buttont = content.Load<Texture2D>("Background/button");
            buttong = content.Load<Texture2D>("Background/gbutton");
            buttonf = content.Load<SpriteFont>("Font");
            beginbg = content.Load<Texture2D>("Background/bg1");
        }
            public void ButtonDraw(bool nextlevel)
            {
            var button = new knop(buttont, buttonf);
            var buttonQ = new knop(buttont, buttonf);
            if (nextlevel)
            {
                button = new knop(buttong, buttonf)
                {
                    pos = new Vector2(400, 200),
                    displaytext = "Ga naar level 2",

                };

                button.clicker += GOTONEXTLEVEL;

                 buttonQ = new knop(buttong, buttonf)
                {
                    pos = new Vector2(400, 250),
                    displaytext = "Exit",
                };

                buttonQ.clicker += STOP_CLICK;
            }
            if (!nextlevel)
            {
                button = new knop(buttont, buttonf)
                {
                    pos = new Vector2(430, 200),
                    displaytext = "Nieuw spel",

                };

                button.clicker += NEWGameButton_Click;

                buttonQ = new knop(buttont, buttonf)
                {
                    pos = new Vector2(430, 250),
                    displaytext = "Exit",
                };

                buttonQ.clicker += STOP_CLICK;
            }
            screen = new List<screen>()
            {
                button,
                buttonQ,
            };
        }
        public override void Draw(GameTime gameTime, SpriteBatch sprite)
        {
            sprite.Begin();
            sprite.Draw(beginbg, new Rectangle(0, 0, 1000, 500), Color.White);
            foreach (var screen in screen)
                screen.Draw(gameTime, sprite);
            sprite.End();
        }

        public override void Update(GameTime gameTime)
        {
            foreach(var screen in screen)
                screen.Update(gameTime);
        }
        public void STOP_CLICK(object sender, EventArgs e)
        {
            gamee.Exit();
        }
        public void NEWGameButton_Click(object sender, EventArgs e)
        {
            gamee.state(new Game(gamee, graphicsDevice, content,false));
        }
        public void GOTONEXTLEVEL(object sender, EventArgs e)
        {
            gamee.state(new Game(gamee, graphicsDevice, content,true));
        }
    }
}
