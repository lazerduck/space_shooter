using System;
using System.Diagnostics;
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
    class multi_shot
    {
        Random pos_start = new Random();
        public Rectangle hit_rect;
        int dist = 0;
        int count = 0;
        public int health = 5;
        public bool flash = false;
        public multi_shot()
        {
            hit_rect = new Rectangle(pos_start.Next(100, 820), -60, resources.multi_shot.Width, resources.multi_shot.Height);
            dist = pos_start.Next(100, 300);
        }
        public void update()
        {
            if(hit_rect.Y<dist)
            {
            hit_rect.Y += 3;
            }
            else 
            {
                if (count == 60)
                {
                    enemy_bullet new_bull0 = new enemy_bullet(hit_rect.X + (resources.multi_shot.Width / 2), hit_rect.Y + resources.multi_shot.Height, 0, 7);
                    enemy_bullet new_bulll1 = new enemy_bullet(hit_rect.X + (resources.multi_shot.Width / 2) - 12, hit_rect.Y + resources.multi_shot.Height - 7, -5, 5);
                    enemy_bullet new_bulll2 = new enemy_bullet(hit_rect.X + (resources.multi_shot.Width / 2) - 20, hit_rect.Y + resources.multi_shot.Height - 15, -7, 3);
                    enemy_bullet new_bullr1 = new enemy_bullet(hit_rect.X + (resources.multi_shot.Width / 2) + 12, hit_rect.Y + resources.multi_shot.Height - 7, 5, 5);
                    enemy_bullet new_bullr2 = new enemy_bullet(hit_rect.X + (resources.multi_shot.Width / 2) + 19, hit_rect.Y + resources.multi_shot.Height -15, 7, 3);
                    resources.bull.Add(new_bull0);
                    resources.bull.Add(new_bulll1);
                    resources.bull.Add(new_bulll2);
                    resources.bull.Add(new_bullr1);
                    resources.bull.Add(new_bullr2);
                    count = 0;
                }
                count++;
            }

        }
        public void draw()
        {
            if (!flash)
            {
                resources.spritebatch.Draw(resources.multi_shot, hit_rect, Color.White);
            }
            else
            {
                flash = false;
            }
        }
    }
}
