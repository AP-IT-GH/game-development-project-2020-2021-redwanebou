using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using game.Interfaces;
using Microsoft.Xna.Framework.Audio;

namespace game.Commands
{
   public interface IGameCommand
    {
        void Execute(GameTime gameTime, ITransform transform, Vector2 richting, SoundEffect spring);

        public Vector2 snelheid { get; set; }
        public bool spring { get; set; }
      
    }
}
