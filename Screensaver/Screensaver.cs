using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Drawing;
using System.Windows.Forms;

namespace Screensaver
{
    public class Screensaver : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D backgroundImage;
        Vector2 backgroundPosition;
        Vector2 origin;
        Texture2D snowflakeImage;
        Random random = new Random();
        private const int countSnowflakesInSnowfall = 1000;
        private Snowflake[] SnowFall = new Snowflake[countSnowflakesInSnowfall];
        private Size screenSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        private float snowflakeLayerDepth = 0.5f;

        public Screensaver() //This is the constructor, this function is called whenever the game class is created.
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = Screen.PrimaryScreen.Bounds.Width;
            graphics.PreferredBackBufferHeight = Screen.PrimaryScreen.Bounds.Height;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            InitializationOfSnowflakesOfSnowfall();
            backgroundPosition = new Vector2(0, 0);
            origin = new Vector2(0, 0);
        }

        /// <summary>
        /// This function is automatically called when the game launches to initialize any non-graphic variables.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Automatically called when your game launches to load any game assets (graphics, audio etc.)
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundImage = TextureLoader.Load("background", Content);
            snowflakeImage = TextureLoader.Load("snowflake", Content);
        }

        /// <summary>
        /// Called each frame to update the game. Games usually runs 60 frames per second.
        /// Each frame the Update function will run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            //Update the things FNA handles for us underneath the hood:
            FallingSnowflakes();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game is ready to draw to the screen, it's also called each frame.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            //This will clear what's on the screen each frame, if we don't clear the screen will look like a mess:
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundImage, backgroundPosition, Microsoft.Xna.Framework.Color.White);
            DrawSnowflakesInBuffer();
            spriteBatch.End();
            //Draw the things FNA handles for us underneath the hood:
            base.Draw(gameTime);
        }

        private void InitializationOfSnowflakesOfSnowfall()
        {
            for (int indexOfSnowflake = 0; indexOfSnowflake < countSnowflakesInSnowfall; indexOfSnowflake++)
            {
                SnowFall[indexOfSnowflake] = new Snowflake(screenSize, random);
            }
        }

        private void FallingSnowflakes()
        {
            for (int indexOfSnowflake = 0; indexOfSnowflake < countSnowflakesInSnowfall; indexOfSnowflake++)
            {
                SnowFall[indexOfSnowflake].FallingSnowflake(screenSize, random);
            }
        }

        private void DrawSnowflakesInBuffer()
        {
            foreach (Snowflake snowflake in SnowFall)
            {
                spriteBatch.Draw(snowflakeImage, snowflake.Position, null, Microsoft.Xna.Framework.Color.White, 0.0f, origin, snowflake.scale, SpriteEffects.None, snowflakeLayerDepth);
            }
        }
    }
}
