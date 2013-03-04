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
    class enemy_fighter
    {
        int side = 0;
        int y_speed = 2;
        int bullet_speed = 10;
        double bull_x = 0;
        double bull_y = 0;
        Vector2 angle;
        int timer = 0;
        public Rectangle hit_rect = new Rectangle(0, 0, resources.fighter_enemy.Width, resources.fighter_enemy.Height);
        public enemy_fighter(int side)
        {
            
            this.side = side;
            if (side == 0)
            {
                hit_rect.X = 100;
            }
            if (side == 1)
            {
                hit_rect.X = 900;
            }
           
        }
        public void update()
        {
           timer++;
           hit_rect.Y += y_speed;
           if (timer % 50 == 0)
           {
               angle = new Vector2((hit_rect.X - resources.player_x),(hit_rect.Y - resources.player_y));
               angle.Normalize();
               bull_x = -bullet_speed*angle.X;
               bull_y = -bullet_speed * angle.Y;
               enemy_bullet new_bull = new enemy_bullet(hit_rect.X, hit_rect.Y, (int)bull_x, (int)bull_y);
               resources.bull.Add(new_bull);
           }
           
        }
        public void draw()
        {
            
            resources.spritebatch.Draw(resources.fighter_enemy, hit_rect, Color.White);
        }
    }
}
