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

            old_state = Keyboard.GetState();
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
                player1.update();
                enemy_container.update();
            }
            else
            {
                m_menu.update();
            }
            //hittest for player
            for (int j = 0; j < enemy_container.enemies.Count; j++)
            {
                if(player1.hit_rect.Intersects(enemy_container.enemies[j].hit_rec))
                {
                    explosion new_blast = new explosion(enemy_container.enemies[j].hit_rec.X, enemy_container.enemies[j].hit_rec.Y);
                    boom.Add(new_blast);
                    enemy_container.enemies.RemoveAt(j);
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
                        }
                    }
                    catch (Exception e)
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
            if (!resources.paused)
            {
                bg_stars.draw();
                player1.draw();
                enemy_container.draw();
            }
            if (resources.paused == true)
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
