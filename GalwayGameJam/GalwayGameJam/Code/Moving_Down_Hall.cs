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
    class Moving_Down_Hall
    {
        Texture2D texture;
        public Rectangle rectangle;

        public Vector2 position;
        Vector2 origin;
        Vector2 velocity;

        protected int currentFrame;
        protected int frameHeight;
        protected int frameWidth;

        float timer;
        float interval = 60; //Higher the interval then the slower the change ... dependent on the sprite sheet.

        bool start = false;
        public bool start_Level_Two;

        public bool exit_Hall_way;

        public Moving_Down_Hall(Texture2D newTexture, Vector2 newPostion, int newFrameHeight, int newFrameWidht)
        {
            this.texture = newTexture;
            this.position = newPostion;
            this.frameHeight = newFrameHeight;
            this.frameWidth = newFrameWidht;

            currentFrame = 0;
        }

        public void Update(GameTime gameTime)
        {
            rectangle = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);
            origin = new Vector2(rectangle.Width / 2, rectangle.Height / 2);

            position.X = MathHelper.Clamp(position.X, 362, 1700);

            if (position.X >= 1220 && position.X <= 1225)
            {
                exit_Hall_way = true;
                start_Level_Two = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                AnimateRight(gameTime);
                position.X += 2;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                AnimateLeft(gameTime);
                position.X -= 2;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                //AnimateDown(gameTime);
                //position.Y += 2;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                //AnimateUp(gameTime);
                //position.Y -= 2;
            }
            else velocity = Vector2.Zero;
        }


        public void AnimateDown(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;

            if (timer > interval)
            {
                currentFrame++;
                timer = 0;

                if (currentFrame > 8 || currentFrame < 6)
                {
                    currentFrame = 6;
                }
            }
        }
        public void AnimateUp(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;

            if (timer > interval)
            {
                currentFrame++;
                timer = 0;

                if (currentFrame > 11 || currentFrame < 9)
                {
                    currentFrame = 9;
                }
            }
        }

        public void AnimateRight(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;

            if (timer > interval)
            {
                currentFrame++;
                timer = 0;

                if (currentFrame > 2)
                {
                    currentFrame = 0;
                }
            }
        }

        public void AnimateLeft(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;

            if (timer > interval)
            {
                currentFrame++;
                timer = 0;

                if (currentFrame > 5 || currentFrame < 3)
                {
                    currentFrame = 3;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, rectangle, Color.White, 0f, new Vector2(texture.Width / 2, texture.Height / 2), 1f, SpriteEffects.None, 0f);
        }
    }
}
