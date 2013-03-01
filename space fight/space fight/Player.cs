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
    class Player
    {
        //variables
        int xpos = 470;
        int ypos = 550;
        int max_speed = 10;
        int fire_timer = 0;
        bool bul_bool = true;
        public Rectangle hit_rect;
        KeyboardState kboard = new KeyboardState();
        bool firing = true;
        public List<bullet> bullets = new List<bullet>();
        public List<trail> trails = new List<trail>();
        public Player()
        {
           
        }
        public void update()
        {
            hit_rect = new Rectangle(xpos, ypos, resources.ship.Width, resources.ship.Height);
            kboard = Keyboard.GetState();
            if(kboard.IsKeyDown(Keys.W)|| kboard.IsKeyDown(Keys.Up))
            {
                if (ypos > 10)
                {
                    ypos -= max_speed;
                }
            }
            if (kboard.IsKeyDown(Keys.S) || kboard.IsKeyDown(Keys.Down))
            {
                if (ypos < 600)
                {
                    ypos += max_speed;
                }
            }
            if (kboard.IsKeyDown(Keys.A) || kboard.IsKeyDown(Keys.Left))
            {
                if (xpos > 10)
                {
                    xpos -= max_speed;
                }
            }
            if (kboard.IsKeyDown(Keys.D) || kboard.IsKeyDown(Keys.Right))
            {
                if (xpos < 920)
                {
                    xpos += max_speed;
                }
            }
            if(firing)
            {
                if (kboard.IsKeyDown(Keys.Space))
                {
                    firing = false;
                }
            }
            if(!firing)
            {
                if (kboard.IsKeyDown(Keys.Space))
                {
                    firing = true;
                }
            }
            if (firing)
            {
                if (fire_timer == 5)
                {
                    if (bul_bool)
                    {
                        bullet new_bull = new bullet(xpos+13, ypos+10);
                        bul_bool = false;
                        bullets.Add(new_bull);
                    }
                    else
                    {
                        bullet new_bull = new bullet(xpos+28, ypos+10);
                        bul_bool = true;
                        bullets.Add(new_bull);
                    }
                    
                    fire_timer = 0;
                }
            }
            for (int i = 0; i < bullets.Count;i++ )
            {
                bullets[i].update();
                if (bullets[i].hit_rec.Y < 0)
                {
                    bullets.RemoveAt(i);
                }
            }
            fire_timer++;
            trail new_trail = new trail(xpos+13, ypos+50);
            trails.Add(new_trail);
            for (int i = 0; i < trails.Count; i++)
            {
                if (trails[i].alpha < 0)
                {
                    trails.RemoveAt(i);
                }
                else
                {
                    trails[i].update();
                }
            }
        }
        public void draw()
        {
            for (int i = 0; i < trails.Count; i++)
            {
                trails[i].draw();
            }
            foreach (bullet c in bullets)
            {
                c.draw();
            }
            resources.spritebatch.Draw(resources.ship, new Rectangle(xpos, ypos, 42, 78), Color.White);
        }
    }
}
