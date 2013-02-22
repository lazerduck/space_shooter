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
        public enemys()
        {

        }
        public void update()
        {
            if (count == 15)
            {
                enemy new_enemy = new enemy(0);
                enemies.Add(new_enemy);
                count = 0;
            }
            count++;
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].update();
                if (enemies[i].hit_rec.Y > 720)
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
