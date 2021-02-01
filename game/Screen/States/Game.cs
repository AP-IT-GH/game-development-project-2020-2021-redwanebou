using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using LevelDesign.LevelDesign;
using System.Text;
using game.Input;
using Microsoft.Xna.Framework.Audio;
using TiledSharp;
using System.Diagnostics;
using game.Valsstrik;
using game.Interfaces;
using game.Commands;
using game.kogel;
using System.Linq;

namespace game.Screen
{
  public class Game : State
    {
        private Camera camera;
        private Speler hero;
        private Levels level;
        private enemys enemy;
        private exit ex;
        private val vals;
        private bool lvl;
        private SoundEffect spring;
        private Texture2D bgtexture, texture,valsstrik,exit;
        public Game(Game1 game, GraphicsDevice graphics, ContentManager content,bool lvl) : base(game, graphics, content) {
            this.lvl = lvl;
            LoadContent();
        }

        public void LoadContent()
        {
            level = new Levels(content);
            level.CreateWorld(lvl);
            enemy = new enemys(content, level.colli, lvl);
            enemy.CreateEnemy();
            camera = new Camera(graphicsDevice.Viewport);
            texture = content.Load<Texture2D>("Hero/spritesheet");
            valsstrik = content.Load<Texture2D>("Level/dood");
            exit = content.Load<Texture2D>("Level/exit");
            hero = new Speler(texture, level.colli,content);
            spring = content.Load<SoundEffect>("Geluid/spring");
            if (!lvl) bgtexture = content.Load<Texture2D>("Background/level1background"); else { bgtexture = content.Load<Texture2D>("Background/level2background"); }
            ex = new exit(exit, lvl);
            vals = new val(valsstrik);
            vals.CreateVal();
        }

        public override void Update(GameTime gameTime){
            hero.Update(gameTime, spring);
            camera.Update(hero.positie, 1798, 1798);
            CheckTheState();
        }

        public void CheckTheState()
        {
            if (!enemy.Geraakt(hero.CollisionRectangle))
                enemy.Update();

            if (vals.Gestorven(hero.CollisionRectangle) || enemy.Geraakt(hero.CollisionRectangle))
                gamee.state(new Death(gamee, graphicsDevice, content));

            if (ex.CheckNextLevel(hero.CollisionRectangle))
                if (!lvl) gamee.state(new Menu(gamee, graphicsDevice, content, true)); else gamee.state(new End(gamee, graphicsDevice, content));

            // check if enemy died or the bullet hit the blok //
            foreach (int i in Enumerable.Range(0, hero.kogels.Count))
            {
            if (enemy.Geraakt(hero.kogels[i].enemybullet))
                enemy.DeleteEnemy();
            if (level.BulletGeraakt(hero.kogels[i].enemybullet))
                hero.kogels[i].IsRemoved = true;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch sprite)
        {
            sprite.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Mat);
            sprite.Draw(bgtexture, new Rectangle(0, 510, 1798, 1291), Color.White);
            hero.Draw(sprite);
            level.DrawWorld(sprite);
            enemy.DrawEnemy(sprite);
            vals.Draw(sprite);
            ex.Draw(sprite);
            sprite.End();
        }
    }
}
