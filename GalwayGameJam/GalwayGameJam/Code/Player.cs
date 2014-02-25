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
    static class Constants
    {
        public const int tileCountX = 11;
        public const int tileCountY = 9;
        public const int tileSizeX = 32;
        public const int tileSizeY = 32;
    }


    public class Player : AnimationEntity
    {
        public float speed = 2;
        public float shootSpeed = 25;
        public float shootCounter;
        public Vector2 direction;
        public int health = 100;

        public Player(Game1 game, AnimatedTexture playerAnimation)
        {
            position.X = 5 * Constants.tileSizeX;
            position.Y = 5 * Constants.tileSizeY;
            shootCounter = shootSpeed; // Start with full shoot counter so that we can shoot immediately
            direction = new Vector2(0, -1);
            animation = playerAnimation;
        }

        public override void update(Game1 game, GameTime gameTime)
        {
            shootCounter++;

            position.X = MathHelper.Clamp(position.X, 0, 840);
            position.Y = MathHelper.Clamp(position.Y, 0, 580);

            KeyboardState keyboard = Keyboard.GetState();

            Vector2 newDirection = new Vector2(0, 0);

            if (keyboard.IsKeyDown(Keys.Up))
            {
                newDirection.Y = -1;
                animation.StartFrame = 9;
                animation.EndFrame = 11;
            }

            if (keyboard.IsKeyDown(Keys.Down))
            {
                newDirection.Y = 1;
                animation.StartFrame = 6;
                animation.EndFrame = 8;
            }

            if (keyboard.IsKeyDown(Keys.Left))
            {
                newDirection.X = -1;
                animation.StartFrame = 3;
                animation.EndFrame = 5;
            }

            if (keyboard.IsKeyDown(Keys.Right))
            {
                newDirection.X = 1;
                animation.StartFrame = 0;
                animation.EndFrame = 2;
            }

            if (keyboard.IsKeyUp(Keys.Left) && keyboard.IsKeyUp(Keys.Right) && keyboard.IsKeyUp(Keys.Up) && keyboard.IsKeyUp(Keys.Down))
            {
                animation.Pause();
            }
            else
            {
                animation.Play();
            }

            if (newDirection.X != 0 || newDirection.Y != 0)
            {
                Vector2 newVelocity = newDirection * speed;

                Rectangle simulatedRectangle = getRectangle();
                simulatedRectangle.X += (int)newVelocity.X;
                simulatedRectangle.Y += (int)newVelocity.Y;

                // Check for collisions
                Boolean collided = false;

                foreach (Entity e in game.entities)
                {
                    if (e is SolidObject)
                    {
                        if (e.testCollision(simulatedRectangle))
                        {
                            collided = true;
                            break;
                        }
                    }
                }

                direction = newDirection;

                if (collided)
                {
                    velocity = new Vector2(0, 0);
                }
                else
                {
                    velocity = newVelocity;
                }
            }
            else
            {
                velocity = new Vector2(0, 0);
            }

            if (keyboard.IsKeyDown(Keys.Space))
            {
                if (shootCounter > shootSpeed)
                {
                    Vector2 projectilePosition = position;
                    projectilePosition.X += animation.getWidth() / 2;
                    projectilePosition.Y += animation.getHeight() / 2;
                    game.entities.Add(new Projectile(game, projectilePosition, direction, this));
                    shootCounter = 0;
                }
            }

            base.update(game, gameTime);
        }

        public override void onCollide(Entity entity, Game1 game)
        {
            if (entity is Enemy)
            {
                health--;
            }
        }
    }
}
