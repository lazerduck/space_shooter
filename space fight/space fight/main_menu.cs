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
    class main_menu
    {
        Rectangle play_btn = new Rectangle(405,100,130,70);
        Rectangle exit_btn = new Rectangle(405,300,130,70);
        Rectangle fullscreen_btn = new Rectangle(405,500,130,70);
        MouseState mouse_click;
        MouseState old_mouse;

        public main_menu()
        {
            old_mouse = Mouse.GetState();
        }
        public void update()
        {
            mouse_click = Mouse.GetState();
            if (play_btn.Contains(mouse_click.X, mouse_click.Y))
            {
                if (old_mouse.LeftButton == ButtonState.Pressed)
                {
                    if (mouse_click.LeftButton == ButtonState.Released)
                    {
                        resources.paused = false;
                    }
                }
            }
            if (exit_btn.Contains(mouse_click.X, mouse_click.Y))
            {
                if (old_mouse.LeftButton == ButtonState.Pressed)
                {
                    if (mouse_click.LeftButton == ButtonState.Released)
                    {
                        resources.exit = true;
                    }
                }
            }
            if (fullscreen_btn.Contains(mouse_click.X, mouse_click.Y))
            {
                if (old_mouse.LeftButton == ButtonState.Pressed)
                {
                    if (mouse_click.LeftButton == ButtonState.Released)
                    {
                        if (resources.graphics.IsFullScreen == false)
                        {
                            resources.graphics.IsFullScreen = true;
                            resources.graphics.ApplyChanges();
                        }
                        else
                        {
                            resources.graphics.IsFullScreen = false;
                            resources.graphics.ApplyChanges();
                        }
                    }
                }
            }
            old_mouse = mouse_click;

        }
        public void draw()
        {
            resources.spritebatch.Draw(resources.btn_play, play_btn, Color.White);
            resources.spritebatch.Draw(resources.btn_fullscreen, fullscreen_btn, Color.White);
            resources.spritebatch.Draw(resources.btn_exit, exit_btn, Color.White);
        }
    }
}
