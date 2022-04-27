﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using game.Interfaces;

namespace game.world
{
    public class drawenemy
    {
        public Texture2D _texture { get; set; }
        public Vector2 Positie;
        public drawenemy(Texture2D texture, Vector2 pos)
        {
            _texture = texture;
            Positie = pos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Positie, Color.AliceBlue);
        }
    }
}
