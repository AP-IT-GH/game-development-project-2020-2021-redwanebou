using game.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using game.world;
using game.Collision;
using System.Diagnostics;
using LevelDesign.LevelDesign;

namespace game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;


        private SpriteBatch _spriteBatch;
        // texture is de afbeelding zelf //
        private Texture2D texture, bgTexture;
        Speler hero;
        Level level;
        CollisionManager collisionManager;



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
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // laad image in //
            texture = Content.Load<Texture2D>("spritesheet");
            // laad background in //
            bgTexture = Content.Load<Texture2D>("bg");


            InitializeGameObjects();

        }

        // zet de objecten klaar //
        private void InitializeGameObjects()
        {
           hero = new Speler(texture, new Toetsenbord());
          collisionManager = new CollisionManager();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            hero.Update(gameTime);

            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            _spriteBatch.Begin();
            _spriteBatch.Draw(bgTexture, new Vector2(0, 0), Color.White);
            hero.Draw(_spriteBatch);
            level.DrawWorld(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
