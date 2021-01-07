using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using game.world;
using game.Interfaces;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace LevelDesign.LevelDesign
{
    public class Level
    {

        public Texture2D texture;

        public byte[,] tileArray = new Byte[,]
        {
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,1 },
            {0,0,0,1,0,0 },
            {0,0,1,0,0,0 },
        };

        private Blok[,] blokArray = new Blok[6, 6];

        private ContentManager content;

        public List<Rectangle> colli = new List<Rectangle>();


        public Level(ContentManager content)
        {
            this.content = content;

            InitializeContent();
        }

        private void InitializeContent()
        {
            texture = content.Load<Texture2D>("blok");
        }


        public void CreateWorld()
        {
            for (int x = 0; x < 6; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    if (tileArray[x, y] == 1)
                    {
                        blokArray[x, y] = new Blok(texture, new Vector2(y * 128, x * 64));

                        colli.Add(new Rectangle(y * 128, x * 64, 120, 64));
                    }
                }
            }
        }

        public void DrawWorld(SpriteBatch spritebatch)
        {
            for (int x = 0; x < 6; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    if (blokArray[x, y] != null)
                    {
                        blokArray[x, y].Draw(spritebatch);
                    }
                }
            }

        }
    }
}