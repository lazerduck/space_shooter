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
        public List<enemy_fighter> fighter_enemy = new List<enemy_fighter>();
        public List<multi_shot> multi_enemy = new List<multi_shot>();
        int count = 0;
        bool en = true;
        Random enemy_pattern = new Random();
        int timer = 0;
        public enemys()
        {
            timer = enemy_pattern.Next(30, 100);
        }
        public void update()
        {
            for (int i = 0; i < resources.bull.Count; i++)
            {
                resources.bull[i].update();
            }
            if (resources.death)
            {
                enemies.Clear();
                fighter_enemy.Clear();
                resources.bull.Clear();
                multi_enemy.Clear();
                
            }
            if (resources.reset)
            {
                resources.reset = false;
            }
            count++;
            if (count%300 - resources.score/20 == 0)
            {
                multi_shot new_multi = new multi_shot();
                multi_enemy.Add(new_multi);
            }
            if (count % 60 - resources.score/20== 0)
            {
                enemy new_enemy = new enemy(3);
                enemies.Add(new_enemy);
            }
            if (count%120 - resources.score/20 == 0)
            {
                if (en)
                {
                    en = false;
                    enemy_fighter new_fighter = new enemy_fighter(0);
                    fighter_enemy.Add(new_fighter);
                }
                else
                {
                    en = true;
                    enemy_fighter new_fighter = new enemy_fighter(1);
                    fighter_enemy.Add(new_fighter);

                }
                
            }
             
            //updates
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].update();
                if (resources.death)
                {
                    if (enemies[i].hit_rec.Y > 600)
                    {
                        enemies.RemoveAt(i);
                    }
                }
                if (enemies[i].hit_rec.Y > 800)
                {
                    enemies.RemoveAt(i);
                }
            }
            for (int i = 0; i < fighter_enemy.Count; i++)
            {
                if (fighter_enemy[i].hit_rect.Y > 800)
                {
                    fighter_enemy.RemoveAt(i);
                }
            }
            for (int i = 0; i < fighter_enemy.Count; i++)
            {
                fighter_enemy[i].update();
                if (resources.death)
                {
                    if (fighter_enemy[i].hit_rect.Y > 600)
                    {
                        fighter_enemy.RemoveAt(i);
                    }
                }
                if (fighter_enemy[i].hit_rect.Y > 800)
                {
                    fighter_enemy.RemoveAt(i);
                }
            }
            for (int i = 0; i < multi_enemy.Count; i++)
            {

                multi_enemy[i].update();
                if (multi_enemy[i].hit_rect.Y > 600)
                {
                    fighter_enemy.RemoveAt(i);
                }
            }

        }
        public void draw()
        {
            for (int i = 0; i < resources.bull.Count; i++)
            {
                resources.bull[i].draw();
            }
            foreach (enemy e in enemies)
            {
                e.draw();
            }
            foreach (enemy_fighter e in fighter_enemy)
            {
                e.draw();
            }
            foreach (multi_shot m in multi_enemy)
            {
                m.draw();
            }
        }
    }
}
