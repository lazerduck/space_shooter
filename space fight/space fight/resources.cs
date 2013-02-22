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
    class resources
    {
        public static bool paused = true;
        public static bool exit = false;
        public static Texture2D ship;
        public static Texture2D bullet;
        public static Texture2D enemy;
        public static Texture2D star;
        public static Texture2D btn_play;
        public static Texture2D btn_exit;
        public static Texture2D btn_fullscreen;
        public static SpriteFont font;
        public static SpriteBatch spritebatch;
        public static KeyboardState kboard = new KeyboardState();
        public static GraphicsDeviceManager graphics;
    }
}
