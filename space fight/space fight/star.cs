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
    class star
    {
        Random rnd_get = new Random();
        int xpos = 0;
        int ypos = 0;
        public Rectangle draw_rect = new Rectangle(0, 0, 5, 5);
        public star()
        {
            xpos = rnd_get.Next(0, 960);
            ypos = rnd_get.Next(10, 20);
        }
        public void update()
        {
            draw_rect.X = xpos;
            draw_rect.Y += ypos;
        }
        public void draw()
        {
            resources.spritebatch.Draw(resources.star, draw_rect, Color.White);
        }
    }
}
