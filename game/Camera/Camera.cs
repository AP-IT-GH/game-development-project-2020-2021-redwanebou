using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace game
{
   public class Camera
    {
        private Vector2 centre;
        private Viewport view;
        private Matrix mat;
        public Matrix Mat
        {
            get { return mat; }
        }

        public Camera(Viewport nview)
        {
            view = nview;
        }

        public void Update(Vector2 positie, int x, int y)
        {
            if (positie.X < view.Width / 2)
            {
                centre.X = view.Width / 2;
            }
            else if (positie.X > x - (view.Width / 2))
            {
                centre.X = x - (view.Width / 2);
            }
            else
            {
                centre.X = positie.X;
            }

            // hetzelfde voor Y //

            if (positie.Y < view.Height / 2)
            {
                centre.Y = view.Height / 2;
            }
            else if (positie.Y > y - (view.Height / 2))
            {
                centre.Y = x - (view.Height / 2);
            }
            else
            {
                centre.Y = positie.Y;
            }

            mat = Matrix.CreateTranslation(new Vector3(-centre.X + (view.Width / 2), -centre.Y + (view.Height / 2), 0));
        }

    }
}
