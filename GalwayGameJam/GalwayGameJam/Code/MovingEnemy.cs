using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GalwayGameJam
{
    public class MovingEnemy : Enemy
    {
        int distanceMax;
        int distanceCount;
        Vector2 origVelocity;

        public MovingEnemy(Texture2D mytexture, Game1 game, Vector2 myposition, Vector2 myvelocity, int mydistance)
            : base(mytexture, game, myposition)
        {
            position = myposition;
            texture = mytexture;
            origVelocity = velocity = myvelocity;
            distanceMax = mydistance;
            distanceCount = 0;
        }

        public override void update(Game1 game, GameTime gameTime)
        {
            distanceCount++;

            if (distanceCount > distanceMax)
            {
                origVelocity = velocity = velocity * -1;
                distanceCount = 0;
            }

            // Check for collisions
            Rectangle simulatedRectangle = getRectangle();
            simulatedRectangle.X += (int)velocity.X;
            simulatedRectangle.Y += (int)velocity.Y;

            Boolean collided = false;

            foreach (Entity e in game.entities)
            {
                if (e != this && (e is SolidObject || e is Enemy))
                {
                    if (e.testCollision(simulatedRectangle))
                    {
                        collided = true;
                        break;
                    }
                }
            }

            // don't move if collided
            if (!collided)
            {
                position.X += velocity.X;
                position.Y += velocity.Y;
            }
            // collided with player - stand still
            if (game.player.testCollision(getRectangle()))
            {
                velocity.X = 0;
                velocity.Y = 0;
            }
        }

    }
}
