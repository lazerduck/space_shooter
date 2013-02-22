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
        SpriteFont font;

        //objects
        Player player1 = new Player();
        enemys enemy_container = new enemys();
        stars bg_stars = new stars();

        //declare vaiables
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 680;
            graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            

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
            resources.star = star;
            resources.font = font;
            resources.enemy = enemy;
            resources.bullet = bullet;
            resources.ship = Player_ship;
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

            if (resources.kboard.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
            //object updates
            bg_stars.update();
            player1.update();
            enemy_container.update();

            //hittest for bullets/enemies
            for (int i = 0; i < player1.bullets.Count; i++)
            {
                for (int j = 0; j < enemy_container.enemies.Count; j++)
                {
                    if (enemy_container.enemies[j].hit_rec.Contains(player1.bullets[i].hit_rec.X, player1.bullets[i].hit_rec.Y))
                    {
                        player1.bullets.RemoveAt(i);
                        enemy_container.enemies.RemoveAt(j);
                    }
                    
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            bg_stars.draw();
            player1.draw();
            enemy_container.draw();

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
