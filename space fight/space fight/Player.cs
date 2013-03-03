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
        int pow_time = 50;
        int xpos = 470;
        int ypos = 550;
        int max_speed = 10;
        int fire_timer = 0;
        bool bul_bool = true;
        public Rectangle hit_rect;
        KeyboardState kboard = new KeyboardState();
        public List<bullet> bullets = new List<bullet>();
        public List<trail> trails = new List<trail>();
        public List<powerups> power = new List<powerups>();
        bool launch = false;
        public Player()
        {
           
        }
        public void update()
        {
            if(resources.death)
            {
                power.Clear();
            }
            //player/power hittest
            for (int i = 0; i < power.Count; i++)
            {
                if (power[i].hit_box.Intersects(hit_rect))
                {
                    power.RemoveAt(i);
                    resources.power_level++;
                }
            }
            
            if ((resources.score%pow_time) == 0 && (resources.score!= 0) && (!launch))
            {
                powerups new_power = new powerups();
                power.Add(new_power);
                pow_time = pow_time*2;
                launch = true;
            }
            if ((launch) && (resources.score % pow_time != 0))
            {
                launch = false;
            }
            for(int i = 0; i < power.Count; i++)
            {
                if (power[i].hit_box.Y > 800)
                {
                    power.RemoveAt(i);
                }
                else
                {
                    power[i].update();
                }
            }
            if (resources.reset)
            {
                ypos = 550;
                xpos = 470;
            }
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
           switch(resources.power_level)
           {
               case 0:
                if (fire_timer == 5)
                {
                    
                    if (bul_bool)
                    {
                        bullet new_bull = new bullet(xpos+13, ypos+10,0);
                        bul_bool = false;
                        bullets.Add(new_bull);
                    }
                    else
                    {
                        bullet new_bull = new bullet(xpos+28, ypos+10,0);
                        bul_bool = true;
                        bullets.Add(new_bull);
                    }
                    
                    fire_timer = 0;
                
                }
                break;
               case 1:
                if (fire_timer == 5)
                {
                    bullet new_bull = new bullet(xpos + 13, ypos + 10, 0);
                    bullet new_bull2 = new bullet(xpos + 28, ypos + 10, 0);
                    bullets.Add(new_bull);
                    bullets.Add(new_bull2);
                    fire_timer = 0;
                }
                break;
               case 2:
                if (fire_timer == 5)
                {

                    if (bul_bool)
                    {
                        bullet new_bull = new bullet(xpos + 13, ypos + 10, 0);
                        bullet new_bull2 = new bullet(xpos + 28, ypos + 10, 2);
                        bul_bool = false;
                        bullets.Add(new_bull);
                        bullets.Add(new_bull2);
                    }
                    else
                    {
                        bullet new_bull = new bullet(xpos + 28, ypos + 10, 0);
                        bullet new_bull2 = new bullet(xpos + 13, ypos + 10, 1);
                        bul_bool = true;
                        bullets.Add(new_bull);
                        bullets.Add(new_bull2);
                    }

                    fire_timer = 0;

                }
                break;
               case 3:
                if (fire_timer == 5)
                {
                    bullet new_bull = new bullet(xpos + 13, ypos + 10, 0);
                    bullet new_bull2 = new bullet(xpos + 28, ypos + 10, 0);
                    bullet new_bull3 = new bullet(xpos + 28, ypos + 10, 2);
                    bullet new_bull4 = new bullet(xpos + 13, ypos + 10, 1);
                    bullets.Add(new_bull);
                    bullets.Add(new_bull2);
                    bullets.Add(new_bull3);
                    bullets.Add(new_bull4);
                    fire_timer = 0;
                }
                break;
               case 4:
                if (fire_timer == 5)
                {

                    if (bul_bool)
                    {
                        bullet new_bull = new bullet(xpos + 13, ypos + 10, 0);
                        bullet new_bull3 = new bullet(xpos + 28, ypos + 10, 2);
                        bullet new_bull4 = new bullet(xpos + 28, ypos + 20, 3);
                        bul_bool = false;
                        bullets.Add(new_bull);
                        bullets.Add(new_bull3);
                        bullets.Add(new_bull4);
                    }
                    else
                    {
                        bullet new_bull = new bullet(xpos + 28, ypos + 10, 0);
                        bullet new_bull3 = new bullet(xpos + 13, ypos + 10, 1);
                        bullet new_bull4 = new bullet(xpos + 13, ypos + 20, 4);
                        bul_bool = true;
                        bullets.Add(new_bull);
                        bullets.Add(new_bull3);
                        bullets.Add(new_bull4);
                    }

                    fire_timer = 0;

                }
                break;
                   case 5:
                if (fire_timer == 5)
                {

                    bullet new_bull = new bullet(xpos + 13, ypos + 10, 0);
                    bullet new_bull3 = new bullet(xpos + 28, ypos + 10, 2);
                    bullet new_bull4 = new bullet(xpos + 28, ypos + 20, 3);
                    bul_bool = false;
                    bullets.Add(new_bull);
                    bullets.Add(new_bull3);
                    bullets.Add(new_bull4);
                    bullet new_bull2 = new bullet(xpos + 28, ypos + 10, 0);
                    bullet new_bull1 = new bullet(xpos + 13, ypos + 10, 1);
                    bullet new_bull5 = new bullet(xpos + 13, ypos + 20, 4);
                    bul_bool = true;
                    bullets.Add(new_bull2);
                    bullets.Add(new_bull1);
                    bullets.Add(new_bull5);
                    fire_timer = 0;

                }
                break;
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
            for (int i = 0; i < power.Count; i++)
            {
                power[i].draw();
            }
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
