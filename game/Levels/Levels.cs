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
    public class Levels
    {

        public Texture2D blok1,blok2,blok3;

        // level 1 //
        public byte[,] level1 = new Byte[,]
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, 
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, 
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, 
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, 
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, 
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, 
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,0,0,0,0,0,0,0,3,0},
            {0,0,0,1,0,1,0,1,1,1,1,1,0,0,0,1,0,1,0,0,0,3,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0},
            {3,0,0,0,0,0,3,3,3,3,3,0,0,0,0,3,3,0,3,0,0,0,0,0},
            {0,0,0,0,0,2,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,2,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        };

        // level 2 //
        public byte[,] level2 = new Byte[,]
  {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,2,0,2,0,2,0,3,3,3,3,3,0,3,0,0,0},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
            {0,0,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,2,0,2,0,2,0,0,0,0},
            {0,0,0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
  };

        private drawlevel[,] blokArray = new drawlevel[24, 24];

        private ContentManager content;

        public List<Rectangle> colli = new List<Rectangle>();

        public Levels(ContentManager content)
        {
            this.content = content;

            InitializeContent();
        }

        private void InitializeContent()
        {
            blok1 = content.Load<Texture2D>("Level/blok1");
            blok2 = content.Load<Texture2D>("Level/blok2");
            blok3 = content.Load<Texture2D>("Level/blok3");
        }

        public bool BulletGeraakt(Rectangle bullet)
        {
            foreach (Rectangle check in colli)
                if (check.Intersects(bullet))
                return true;

            return false;
        }

        public void CreateWorld(bool level)
        {
            if (!level)
            {
                for (int x = 0; x < 24; x++)
                {
                    for (int y = 0; y < 24; y++)
                    {
                        switch (level1[x, y])
                        {
                            case 1:
                                blokArray[x, y] = new drawlevel(blok1, new Vector2(y * 70, x * 70));
                                break;
                            case 2:
                                blokArray[x, y] = new drawlevel(blok2, new Vector2(y * 70, x * 70));
                                break;
                            case 3:
                                blokArray[x, y] = new drawlevel(blok3, new Vector2(y * 70, x * 70));
                                break;
                            default:
                                break;
                        }
                        if (level1[x, y] != 0)
                        {
                            // alle blokken hebben dezelfde width en height dus maakt niet uit voor collision //
                            colli.Add(new Rectangle(y * 70, x * 70, 57, 70));
                        }
                    }
                }
            }
            if (level)
            {
                for (int x = 0; x < 24; x++)
                {
                    for (int y = 0; y < 24; y++)
                    {
                        switch (level2[x, y])
                        {
                            case 1:
                                blokArray[x, y] = new drawlevel(blok1, new Vector2(y * 70, x * 70));
                                break;
                            case 2:
                                blokArray[x, y] = new drawlevel(blok2, new Vector2(y * 70, x * 70));
                                break;
                            case 3:
                                blokArray[x, y] = new drawlevel(blok3, new Vector2(y * 70, x * 70));
                                break;
                            default:
                                break;
                        }
                        if (level2[x, y] != 0)
                        {
                            // alle blokken hebben dezelfde width en height dus maakt niet uit voor collision //
                            colli.Add(new Rectangle(y * 70, x * 70, 57, 70));
                        }
                    }
                }
            }
        }

        public void DrawWorld(SpriteBatch spritebatch)
        {
            for (int x = 0; x < 24; x++)
            {
                for (int y = 0; y < 24; y++)
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