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
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D Player_ship;
        Texture2D bullet;
        Texture2D enemy;
        Texture2D star;
        Texture2D btn_play;
        Texture2D btn_exit;
        Texture2D btn_fullscreen;
        Texture2D fire;
        Texture2D explosion;
        Texture2D power_up;
        Texture2D btn_restart;
        Texture2D fighter_enemy;
        Texture2D multi_shot;
        Texture2D enemy_bullet;
        SpriteFont font;


        //objects
        Player player1 = new Player();
        enemys enemy_container = new enemys();
        stars bg_stars = new stars();
        main_menu m_menu = new main_menu();

        //declare vaiables
        KeyboardState old_state;
        List<explosion> boom = new List<explosion>();
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            resources.graphics = graphics;
            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 680;
            graphics.IsFullScreen = false;
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //set start conditions for the resources class
            old_state = Keyboard.GetState();
            resources.score = 0;
            resources.death = false;
            resources.reset = false;
            resources.power_level = 0;
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Player_ship = Content.Load<Texture2D>("Ship");
            bullet = Content.Load<Texture2D>("bullet");
            enemy = Content.Load<Texture2D>("enemy");
            font = Content.Load<SpriteFont>("Font1");
            star = Content.Load<Texture2D>("star");
            btn_exit = Content.Load<Texture2D>("exit_btn");
            btn_fullscreen = Content.Load<Texture2D>("fullscreen_btn");
            btn_play = Content.Load<Texture2D>("play_btn");
            fire = Content.Load<Texture2D>("fire");
            explosion = Content.Load<Texture2D>("explosion");
            power_up = Content.Load<Texture2D>("power_up");
            btn_restart = Content.Load<Texture2D>("restart_btn");
            fighter_enemy = Content.Load<Texture2D>("fighter_enemy");
            enemy_bullet = Content.Load<Texture2D>("enemy_bullet");
            multi_shot = Content.Load<Texture2D>("multi_shot");
            resources.multi_shot = multi_shot;
            resources.enemy_bullet = enemy_bullet;
            resources.fighter_enemy = fighter_enemy;
            resources.restart_btn = btn_restart;
            resources.power_up = power_up;
            resources.btn_exit = btn_exit;
            resources.explosion = explosion;
            resources.btn_fullscreen = btn_fullscreen;
            resources.btn_play = btn_play;
            resources.star = star;
            resources.font = font;
            resources.enemy = enemy;
            resources.bullet = bullet;
            resources.ship = Player_ship;
            resources.fire = fire;
            resources.spritebatch = spriteBatch;
            

        }    
        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (resources.death)
            {
                player1.power.Clear();
            }
            resources.kboard = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (resources.exit == true)
            {
                this.Exit();
            }

            if (resources.kboard.IsKeyDown(Keys.Escape))
            {
            }
            else if(old_state.IsKeyDown(Keys.Escape))
            {
                if (resources.paused == false)
                {
                    resources.paused = true;
                }
                else
                {
                    resources.paused = false;
                }

            }
            old_state = resources.kboard;
            //object updates
            if (resources.paused == false)
            {
                bg_stars.update();
                if (!resources.death)
                {
                    player1.update(); 
                }
                enemy_container.update();
            }
            else
            {
                m_menu.update();
            }
            if (resources.death)
            {
                m_menu.update();
            }
            if (!resources.death)
            {
                //hittest for player
                for (int j = 0; j < enemy_container.enemies.Count; j++)
                {
                    if (player1.hit_rect.Intersects(enemy_container.enemies[j].hit_rec))
                    {
                        explosion new_blast = new explosion(player1.hit_rect.X, player1.hit_rect.Y);
                        boom.Add(new_blast);
                        resources.death = true;
                        enemy_container.enemies.RemoveAt(j);
                    }
                }
                for (int j = 0; j < enemy_container.fighter_enemy.Count; j++)
                {
                    if (player1.hit_rect.Intersects(enemy_container.fighter_enemy[j].hit_rect))
                    {
                        explosion new_blast = new explosion(player1.hit_rect.X, player1.hit_rect.Y);
                        boom.Add(new_blast);
                        resources.death = true;
                        enemy_container.fighter_enemy.RemoveAt(j);
                    }
                }
                for (int j = 0; j < enemy_container.multi_enemy.Count; j++)
                {
                    if (player1.hit_rect.Intersects(enemy_container.multi_enemy[j].hit_rect))
                    {
                        explosion new_blast = new explosion(player1.hit_rect.X, player1.hit_rect.Y);
                        boom.Add(new_blast);
                        resources.death = true;
                        enemy_container.multi_enemy.RemoveAt(j);
                    }
                }
                //hittest for bullets/enemies
                for (int i = 0; i < player1.bullets.Count; i++)
                {
                    for (int j = 0; j < enemy_container.enemies.Count; j++)
                    {
                        try
                        {
                            if (enemy_container.enemies[j].hit_rec.Intersects(player1.bullets[i].hit_rec))
                            {
                                player1.bullets.RemoveAt(i);
                                explosion new_blast = new explosion(enemy_container.enemies[j].hit_rec.X, enemy_container.enemies[j].hit_rec.Y);
                                enemy_container.enemies.RemoveAt(j);
                                boom.Add(new_blast);
                                resources.score++;
                            }
                            
                        }
                        catch (Exception e)
                        {

                        }

                    }
                }
                //hittest for enemy bullets
                try
                {

                    for (int i = 0; i < resources.bull.Count; i++)
                    {

                        if (resources.bull[i].hit_rec.Intersects(player1.hit_rect))
                        {
                            explosion new_blast = new explosion(player1.hit_rect.X, player1.hit_rect.Y);
                            boom.Add(new_blast);
                            resources.death = true;
                        }

                    }
                   
                }
                catch (Exception q)
                {

                }
                for (int i = 0; i < player1.bullets.Count; i++)
                {
                    for (int j = 0; j < enemy_container.fighter_enemy.Count; j++)
                    {
                        try
                        {
                            if (enemy_container.fighter_enemy[j].hit_rect.Intersects(player1.bullets[i].hit_rec))
                            {
                                player1.bullets.RemoveAt(i);
                                explosion new_blast = new explosion(enemy_container.fighter_enemy[j].hit_rect.X, enemy_container.fighter_enemy[j].hit_rect.Y);
                                enemy_container.fighter_enemy.RemoveAt(j);
                                boom.Add(new_blast);
                                resources.score++;
                            }
                        }
                        catch (Exception t)
                        {

                        }

                    }
                }  
            }
            for (int i = 0; i < player1.bullets.Count; i++)
            {
                for (int j = 0; j < enemy_container.multi_enemy.Count; j++)
                {
                    try
                    {
                        if (enemy_container.multi_enemy[j].hit_rect.Intersects(player1.bullets[i].hit_rec))
                        {
                            player1.bullets.RemoveAt(i);
                            explosion new_blast = new explosion(enemy_container.multi_enemy[j].hit_rect.X, enemy_container.multi_enemy[j].hit_rect.Y);
                            enemy_container.multi_enemy[j].health--;
                            enemy_container.multi_enemy[j].flash = true;
                            if (enemy_container.multi_enemy[j].health < 1)
                            {
                                enemy_container.multi_enemy.RemoveAt(j);
                                boom.Add(new_blast);
                                resources.score++;
                            }
                        }
                    }
                    catch (Exception l)
                    {

                    }

                }
            }
            
            for (int i = 0; i < boom.Count; i++)
            {
                if (boom[i].alpha < 0)
                {
                    boom.RemoveAt(i);
                }
                else
                {
                    boom[i].update();
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            spriteBatch.DrawString(font, "score: " + resources.score, new Vector2(800, 20), Color.White);
            if (!resources.paused)
            {
                bg_stars.draw();
                if (!resources.death)
                {
                    player1.draw();
                }
                enemy_container.draw();
            }
            if ((resources.paused == true) || (resources.death == true))
            {
                m_menu.draw();
            }
            for (int i = 0; i < boom.Count; i++)
            {
                boom[i].draw();
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
