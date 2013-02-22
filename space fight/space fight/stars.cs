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
    class stars
    {
        List<star> star_cont = new List<star>();
        public stars()
        {

        }
        public void update()
        {
            star new_star = new star();
            star_cont.Add(new_star);
            star new_star1 = new star();
            star_cont.Add(new_star1);
            for (int i = 0; i < star_cont.Count; i++)
            {
                star_cont[i].update();
                if (star_cont[i].draw_rect.Y > 680)
                {
                    star_cont.RemoveAt(i);
                }
            }
        }
        public void draw()
        {
            for (int i = 0; i < star_cont.Count; i++)
            {
                star_cont[i].draw();
            }
        }
    }
}
