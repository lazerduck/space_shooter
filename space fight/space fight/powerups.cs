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
    class powerups
    {
        Random starpos = new Random();
        public Rectangle hit_box = new Rectangle(0, 0, resources.power_up.Width, resources.power_up.Height);
        public powerups()
        {
            hit_box.X = starpos.Next(100, 700);
        }
        public void update()
        {
            hit_box.Y += 2;
            hit_box.X += (int)(Math.Sin(hit_box.Y /50) * 10);
        }
        public void draw()
        {
            resources.spritebatch.Draw(resources.power_up, hit_box, Color.White);
        }
    }
}
