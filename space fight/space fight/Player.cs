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
        int xpos = 100;
        int ypos = 300;
        int max_speed = 5;
        int fire_timer = 0;
        public Rectangle hit_rect;
        KeyboardState kboard = new KeyboardState();
        bool firing = true;
        List<bullet> bullets = new List<bullet>();
        public Player()
        {
           
        }
        public void update()
        {
            hit_rect = new Rectangle(xpos, ypos, 42, 78);
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
                if (ypos < 680)
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
                if (xpos < 980)
                {
                    xpos += max_speed;
                }
            }
            if (kboard.IsKeyDown(Keys.Space))
            {
                firing = false;
            }
            else
            {
                firing = true;
            }
            if (firing)
            {
                if (fire_timer == 3)
                {
                    bullet new_bull = new bullet(xpos,ypos);
                    bullets.Add(new_bull);
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
        }
        public void draw()
        {
            foreach (bullet c in bullets)
            {
                c.draw();
            }
            resources.spritebatch.Draw(resources.ship, new Rectangle(xpos, ypos, 42, 78), Color.White);
        }
    }
}
