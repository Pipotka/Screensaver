using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.Xna.Framework;

namespace Screensaver
{
    struct Snowflake
    {
        public Vector2 Position;
        private int speedOfSnowflake;
        public float scale;

        public Snowflake(Size screenSize, Random randomNumber)
        {
            Position = new Vector2(randomNumber.Next(0, screenSize.Width), randomNumber.Next(-screenSize.Height - 10, -10));
            scale = (randomNumber.Next(10, 15) / 100.0f);
            speedOfSnowflake = 40 / (int)(scale * 100);
        }
        public void FallingSnowflake(Size screenSize, Random randomNumber)
        {
            if (Position.Y < screenSize.Height)
            {
                Position.Y += speedOfSnowflake;
            }
            else
            {
                ChangingSnowflake(screenSize, randomNumber);
            }
        }
        private void ChangingSnowflake(Size screenSize, Random randomNumber)
        {
            Position.X = randomNumber.Next(0, screenSize.Width);
            Position.Y = -30;
            scale = (randomNumber.Next(10, 15) / 100.0f);
            speedOfSnowflake = 40 / (int)(scale * 100);

        }
    }
}
