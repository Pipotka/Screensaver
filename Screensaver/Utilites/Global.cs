using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Screensaver
{
    static class Global
    {
        public static Screensaver game;
        public static Random random = new Random();
        public static string levelName;

        public static void Initialize(Screensaver inputGame)
        {
            game = inputGame;
        }
    }
}
