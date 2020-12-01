using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace game.Animation
{
    class Animationframe
    {
        public Rectangle sourceregtangle { get; set; }


        public Animationframe(Rectangle rectangle){
            sourceregtangle = rectangle;
        }
    
    }
}
