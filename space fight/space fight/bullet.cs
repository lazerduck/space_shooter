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
    class bullet
    {
        int xpos = 0;
        int ypos = 0;
        public Rectangle hit_rec;
        public bullet(int startx, int starty)
        {
            xpos = startx;
            ypos = starty;
            hit_rec = new Rectangle(xpos+15, ypos+60, 10, 20);
        }
        public void update()
        {
            hit_rec.Y -= 20;
        }
        public void draw()
        {
            resources.spritebatch.Draw(resources.bullet, hit_rec, Color.White);
        }
    }
}
