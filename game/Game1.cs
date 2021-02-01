using game.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using game.world;
using game.Collision;
using System.Diagnostics;
using LevelDesign.LevelDesign;
using game.Interfaces;
using game.Screen;
using game.Commands;
using Microsoft.Xna.Framework.Audio;

namespace game
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        /* BRONVERMELDING: https://www.youtube.com/watch?v=76Mz7ClJLoE&ab_channel=Oyyou */
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // alles over scherm //
        private State cstate;
        private State nstate;
        private SoundEffect gamesound;


        public void state(State s)
        {
            nstate = s;
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // enkel noodzakelijk voor camera positie ! //
            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 500;
           _graphics.ApplyChanges();
            gamesound = Content.Load<SoundEffect>("Geluid/gamesound");
            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            cstate = new Menu(this, GraphicsDevice, Content, false);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            gamesound.Play();
        }

        protected override void Update(GameTime gameTime)
        {
            if (nstate != null)
            {
                cstate = nstate;
              // terug resetten //
                nstate = null;
            }

            cstate.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            cstate.Draw(gameTime, _spriteBatch);
            base.Draw(gameTime);
        }
    }
}
