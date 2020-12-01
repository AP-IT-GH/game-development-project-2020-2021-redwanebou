using game.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using game.Collision;
using game.world;
using System.Diagnostics;

namespace game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;


        private SpriteBatch _spriteBatch;
        // texture is de afbeelding zelf //
        private Texture2D texture, blokTexture, bgTexture;
        Hero hero;
        Blok blok;
        CollisionManager collisionManager;
            

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            collisionManager = new CollisionManager();

            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // laad image in //
            texture = Content.Load<Texture2D>("spritesheet");
            // laad de blok in //
            blokTexture = Content.Load<Texture2D>("blok");
            // laad background in //
            bgTexture = Content.Load<Texture2D>("bg");


            InitializeGameObjects();

            // TODO: use this.Content to load your game content here
        }

        // zet de objecten klaar //
        private void InitializeGameObjects()
        {
            hero = new Hero(texture, new Toetsenbord());
            blok = new Blok(blokTexture, new Vector2(100, 400));

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            hero.Update(gameTime);

            blok.Update();

            if (collisionManager.CheckCollision(hero.CollisionRectangle, blok.CollisionRectangle))
            {
                Debug.WriteLine("aaa");
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // scherm wordt 60 keer per seconde gecleard //
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            _spriteBatch.Draw(bgTexture, new Vector2(0, 0), Color.White);
            hero.Draw(_spriteBatch);
            blok.Draw(_spriteBatch);
            _spriteBatch.End();

            

            base.Draw(gameTime);
        }
    }
}
