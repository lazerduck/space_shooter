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
        int type = 0;
        public bullet(int startx, int starty, int type)
        {
            this.type = type;
            xpos = startx;
            ypos = starty;
            hit_rec = new Rectangle(xpos, ypos, 4, 20);
        }
        public void update()
        {
            switch (type)
            {
                case 0:
                    hit_rec.Y -= 20;
                    break;
                case 1:
                    hit_rec.Y -= 15;
                    hit_rec.X -= 5;
                    break;
                case 2:
                    hit_rec.Y -= 15;
                    hit_rec.X += 5;
                    break;
            }
        }
        public void draw()
        {
            resources.spritebatch.Draw(resources.bullet, hit_rec, Color.White);
        }
    }
}
