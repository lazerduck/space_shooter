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
    class enemy
    {
        int xpos = 0;
        int ypos = -78;
        public Rectangle hit_rec;
        int pattern = 0;
        int y_speed = 7;
        Random start = new Random();
       
        public enemy(int pattern)
        {
            xpos = start.Next(0, 920);
            this.pattern = pattern;
            hit_rec = new Rectangle(xpos, ypos, 42, 78);
        }
        public void update()
        {
            hit_rec.Y += y_speed;
            switch (pattern)
            {
                case 0:
                    
                    break;
            }
        }
        public void draw()
        {
            resources.spritebatch.Draw(resources.enemy, hit_rec, Color.White);
        }
    }
}
