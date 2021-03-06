﻿using System;
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
        int direction = 0;
        public Rectangle hit_rec;
        int pattern = 0;
        int y_speed = 5;
        double inc = 0;
        Random start = new Random();
       
        public enemy(int pattern)
        {
            while (direction == 0)
            {
                direction = (int)start.Next(-1, 2);
            }
            
            this.pattern = pattern;
            if (pattern == 0)
            {
                xpos = start.Next(0, 920);
            }
            if (pattern == 1)
            {
                xpos = 100;
            }
            if (pattern == 2)
            {
                xpos = 820;
            }
            if (pattern == 3)
            {
                xpos = start.Next(100, 820);
            }
            hit_rec = new Rectangle(xpos, ypos, resources.enemy.Width, resources.enemy.Height);
        }
        public void update()
        {
            
            switch (pattern)
            {
                case 0:
                    hit_rec.Y += y_speed;
                    break;
                case 1:
                    hit_rec.Y += Convert.ToInt32(y_speed/1.5);
                    hit_rec.X += (int)inc;
                    inc+=0.2f;
                    break;
                case 2:
                    hit_rec.Y += Convert.ToInt32(y_speed/1.5);
                    hit_rec.X -= (int)inc;
                    inc+=0.2f;
                    break;
                case 3:
                    hit_rec.Y += y_speed;
                    hit_rec.X += direction*(int)(Math.Sin(hit_rec.Y/25)*10);
                    break;
            }
        }
        public void draw()
        {
            resources.spritebatch.Draw(resources.enemy, hit_rec, Color.White);
        }
    }
}
