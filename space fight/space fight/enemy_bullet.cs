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
    class enemy_bullet
    {
        Rectangle hit_rec;
        int xspeed, yspeed;
        public enemy_bullet(int xpos, int ypos, int xspeed, int yspeed)
        {
            hit_rec = new Rectangle(xpos, ypos, resources.enemy_bullet.Width, resources.enemy_bullet.Height);
            this.xspeed = xspeed;
            this.yspeed = yspeed;
        }
        public void update()
        {
            hit_rec.X += xspeed;
            hit_rec.Y += yspeed;
        }
        public void draw()
        {
            resources.spritebatch.Draw(resources.enemy_bullet, hit_rec, Color.White);
        }
    }
}
