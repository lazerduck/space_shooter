using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace space_fight
{
    class explosion
    {
        public float alpha = 1f;
        Rectangle box = new Rectangle(0,0,resources.explosion.Width/3, resources.explosion.Height/3);
        public explosion(int x, int y)
        {
            box.X = x;
            box.Y = y;
        }
        public void update()
        {
            alpha -= 0.1f;
        }
        public void draw()
        {
            resources.spritebatch.Draw(resources.explosion, box, Color.White * alpha);
        }
    }
}
