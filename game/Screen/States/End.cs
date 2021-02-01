
using LevelDesign.LevelDesign;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace game.Screen
{
    public class End : State
    {
        /* BRONVERMELDING: https://www.youtube.com/watch?v=76Mz7ClJLoE&ab_channel=Oyyou */
        private List<screen> screen;
        private Texture2D buttont, gameoverbg;
        private SpriteFont buttonf;
        public End(Game1 game, GraphicsDevice graphics, ContentManager content) : base(game, graphics, content)
        {
            InitializeContent();
            ButtonDraw();
        }

        private void InitializeContent()
        {
            buttont = content.Load<Texture2D>("Background/gbutton");
            buttonf = content.Load<SpriteFont>("Font");
            gameoverbg = content.Load<Texture2D>("Background/bg3");
        }

        public void ButtonDraw()
        {
            var button1 = new knop(buttont, buttonf)
            {
                pos = new Vector2(400, 200),
                displaytext = "Terug naar hoofdmenu",
            };

            button1.clicker += GOTOHOME_BUTTON;

            var buttonQ = new knop(buttont, buttonf)
            {
                pos = new Vector2(400, 250),
                displaytext = "Exit",
            };

            buttonQ.clicker += STOP_CLICK;

            screen = new List<screen>()
            {
                button1,
                buttonQ,
            };
        }
        public override void Draw(GameTime gameTime, SpriteBatch sprite)
        {
            sprite.Begin();
            sprite.Draw(gameoverbg, new Rectangle(0, 0, 1000, 500), Color.White);
            foreach (var screen in screen)
            screen.Draw(gameTime, sprite);
            sprite.End();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var screen in screen)
                screen.Update(gameTime);
        }
        public void STOP_CLICK(object sender, EventArgs e)
        {
            gamee.Exit();
        }
        public void GOTOHOME_BUTTON(object sender, EventArgs e)
        {
            gamee.state(new Menu(gamee, graphicsDevice, content, false));
        }
    }
}
