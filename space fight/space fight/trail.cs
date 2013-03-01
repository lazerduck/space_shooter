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
    class trail
    {
        Rectangle box = new Rectangle(0, 0, resources.fire.Width, resources.fire.Height);
        public int timer = 0;
        public float alpha = 1f;
        public trail(int x, int y)
        {
            box.X = x;
            box.Y = y;
        }
        public void update()
        {
            timer++;
            box.Y += 20;
            alpha -= 0.1f;
        }
        public void draw()
        {
            resources.spritebatch.Draw(resources.fire, box, Color.White * alpha);
        }
    }
}
