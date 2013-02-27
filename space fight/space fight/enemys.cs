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
    class enemys
    {
        public List<enemy> enemies = new List<enemy>();
        int count = 0;
        Random enemy_pattern = new Random();
        int timer = 0;
        public enemys()
        {
            timer = enemy_pattern.Next(30, 100);
        }
        public void update()
        {
            count++;
            if (count == 10)
            {
                enemy new_enemy = new enemy(3);
                enemies.Add(new_enemy);
                count = 0;
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].update();
                if (enemies[i].hit_rec.Y > 800)
                {
                    enemies.RemoveAt(i);
                }
            }

        }
        public void draw()
        {
            foreach (enemy e in enemies)
            {
                e.draw();
            }
        }
    }
}
