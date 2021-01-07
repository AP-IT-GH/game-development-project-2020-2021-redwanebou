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
using game.Backgrounds;
using game.Screen;
using game.Commands;
using Microsoft.Xna.Framework.Audio;

namespace game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        // sound effects //
        SoundEffect spring;

        Camera camera;
        private SpriteBatch _spriteBatch;
        // texture is de afbeelding zelf //
        private Texture2D texture;
        Speler hero;
        Level level;
        Toetsenbord toets;
        //  Map map;
        Background bg1;
        Background bg2;


        // alles over scherm //
        private State cstate;
        private State nstate;


        public void state(State s)
        {
            nstate = s;
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            level = new Level(Content);
            level.CreateWorld();
            base.Initialize();

        }

        protected override void LoadContent()
        {
            cstate = new MenuState(this, GraphicsDevice, Content);
            toets = new Toetsenbord();
            bg1 = new Background(Content.Load<Texture2D>("bg"), new Rectangle(0,0,1014,600));
            bg2 = new Background(Content.Load<Texture2D>("bgg"), new Rectangle(1014, 0, 1014, 600));
            spring = Content.Load<SoundEffect>("Geluid/spring");
            camera = new Camera(GraphicsDevice.Viewport);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("spritesheet");
            hero = new Speler(texture, new Toetsenbord(), level.colli);

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

            hero.Update(gameTime,spring);

            if (toets.LeesInput().X == 1)
            {
                bg1.Update();
                bg2.Update();
            }

            camera.Update(hero.positie, 50000, 600);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            cstate.Draw(gameTime, _spriteBatch,bg1,bg2,camera, hero,level);

            base.Draw(gameTime);
        }
    }
}
