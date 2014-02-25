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

namespace GalwayGameJam
{
    class FadeScreen
    {
        Texture2D fadeScreen;
        Vector2 fadeScreenPos = Vector2.Zero;
        Rectangle rectangle;

        Color color;
        public bool fadeIn;
        public bool fadeOut;
        public bool switchToHallway;

        public FadeScreen(ContentManager content)
        {
            fadeScreen = content.Load<Texture2D>("Sprites/black");
            color = Color.White;
            color.A = 0;
        }

        public void Update()
        {
            rectangle = new Rectangle(0, 0, 1000, 1000);

            if (fadeIn == true)
            {
                color.A += 3;

                if (color.A >= 255)
                {
                    switchToHallway = true;
                    fadeOut = true;
                    fadeIn = false;
                }
            }

            if (fadeOut == true)
            {
                color.A -= 3;

                if (color.A <= 0)
                    fadeOut = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(fadeScreen, fadeScreenPos, rectangle, color);
        }
    }
}
