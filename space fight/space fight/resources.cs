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
        public static List<enemy_bullet> bull = new List<enemy_bullet>();
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
        public static Texture2D explosion;
        public static Texture2D fighter_enemy;
        public static SpriteBatch spritebatch;
        public static Texture2D fire;
        public static KeyboardState kboard = new KeyboardState();
        public static GraphicsDeviceManager graphics;
        public static int score;
        public static bool death;
        public static bool reset;
        public static int power_level;
        public static Texture2D power_up;
        public static Texture2D restart_btn;
        public static Texture2D enemy_bullet;
        public static int player_x;
        public static int player_y;
    }
}
