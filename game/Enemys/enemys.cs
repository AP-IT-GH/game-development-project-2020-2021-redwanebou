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
using System.Threading;
using game.Input;
using game.Commands;
using System.Linq;

namespace LevelDesign.LevelDesign
{
    public class enemys
    {
        private List<Rectangle> doodenemy = new List<Rectangle>();
        private List<Rectangle> collienemy = new List<Rectangle>();
        private List<drawenemy> enemyarray = new List<drawenemy>();
        private Texture2D enemy;
        private ContentManager c;
        private Random rnd;
        private int pos, poss;
        private List<Rectangle> collilevel;
        private List<int> rnumbers = new List<int>();
        private int moeilijkheidsgraad;
        private string[] loadpicture = { "enemy1", "enemy2", "enemy3" };
        private int counter;
        private int ct = 000; // default dont delete anything //
        /* welke enemies zijn er al dood? */

        public enemys(ContentManager content, List<Rectangle> levelcolli,bool graad)
        {
            /* declare variables */
            if (!graad) moeilijkheidsgraad = 3; else moeilijkheidsgraad = 2;
            collilevel = levelcolli;
            c = content;
            rnd = new Random();
            // elke game laad een nieuwe enemy //
            poss = rnd.Next(0, 3);
            InitializeContent();
        }

        private void InitializeContent()
        {
            enemy = c.Load<Texture2D>("Enemy/"+loadpicture[poss]);
        }

        public void CreateEnemy()
        {
            // we houden level 1 nog makkelijk en doen delen door 3 anders doen we delen door 2 = meer enemies //
            foreach (int l in Enumerable.Range(0, collilevel.Count / moeilijkheidsgraad - doodenemy.Count))
            {
                // we moeten ervoor zorgen dat het niet 2 keer een enemy op hetzelfde positie gaat tekenen //
                do pos = rnd.Next(0, collilevel.Count);
                while (rnumbers.Contains(pos));

                rnumbers.Add(pos);

                enemyarray.Add(new drawenemy(enemy, new Vector2(collilevel[pos].X, collilevel[pos].Y - 22)));
                collienemy.Add(new Rectangle(collilevel[pos].X, collilevel[pos].Y - 22, enemy.Width, enemy.Height));
            }
        }

        public bool Geraakt(Rectangle bullet)
        {
            foreach (Rectangle check in collienemy)
            {
                if (check.Intersects(bullet))
                {
                    CheckEnemyPosition(check);
                    return true;
                }
            }
            return false;
        }

        public void CheckEnemyPosition(Rectangle detectedenemy)
        {
            for (int jj = 0; jj < collienemy.Count; jj++)
            {
                if (collienemy[jj] == detectedenemy)
                {
                    ct = jj;
                }
            }
        }

        public void DeleteEnemy()
        {
            doodenemy.Add(new Rectangle((int)enemyarray[ct].Positie.X, (int)enemyarray[ct].Positie.Y, enemy.Width, enemy.Height));
            collienemy.RemoveAt(ct);
            enemyarray.RemoveAt(ct);
        }

        public void Update()
        {
            if (counter >= 70)
            {
                counter = 0;
            }
            if (counter >= 35)
            {
                counter++;
                foreach (int kk in Enumerable.Range(0, collilevel.Count / moeilijkheidsgraad - doodenemy.Count))
                   {
                        enemyarray[kk].Positie.X -= 1;
                        collienemy[kk] = new Rectangle((int)enemyarray[kk].Positie.X, (int)enemyarray[kk].Positie.Y - 22, enemyarray[kk]._texture.Width, enemyarray[kk]._texture.Height);
                }
            } else
            {
                counter++;
                foreach (int kk in Enumerable.Range(0, collilevel.Count / moeilijkheidsgraad - doodenemy.Count))
                {
                        enemyarray[kk].Positie.X += 1;
                        collienemy[kk] = new Rectangle((int)enemyarray[kk].Positie.X, (int)enemyarray[kk].Positie.Y - 22, enemyarray[kk]._texture.Width, enemyarray[kk]._texture.Height);
                }
            }
        }

        public void DrawEnemy(SpriteBatch spritebatch)
        {
            foreach (int x in Enumerable.Range(0, collilevel.Count / moeilijkheidsgraad - doodenemy.Count))
            {
                enemyarray[x].Draw(spritebatch);
            }
        }
    }
}