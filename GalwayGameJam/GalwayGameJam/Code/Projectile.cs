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
    public class Projectile : Entity
    {
        public float speed = 6;
        public Entity shooter;

        public Projectile(Game1 game, Vector2 myposition, Vector2 mydirection, Entity myshooter)
        {
            velocity = mydirection * speed;
            position = myposition;
            texture = game.projectileTexture;
            shooter = myshooter;
        }

        public override void update(Game1 game, GameTime gameTime)
        {
            if (position.X < 0 || position.X > 840 || position.Y < 0 || position.Y > 680)
            {
                game.entities.Remove(this);
            }

            base.update(game, gameTime);
        }

        public override void onCollide(Entity entity, Game1 game)
        {
            if (entity != shooter) // don't kill yourself
            {
                if (entity is Enemy)
                {
                    game.entities.Remove(entity);
                    game.entities.Remove(this);
                }
                else if (entity is Player)
                {
                    ((Player)entity).health -= 10;
                    game.entities.Remove(this);
                }
            }
        }

        public override void draw(SpriteBatch batch)
        {
            float rotation = 0;

            if (velocity.X > 0)
            {
                if (velocity.Y == 0)
                {
                    rotation = 90;
                }
                else if (velocity.Y < 0)
                {
                    rotation = 45;
                }
                else if (velocity.Y > 0)
                {
                    rotation = 135;
                }
            }
            else if (velocity.X == 0)
            {
                if (velocity.Y == 0)
                {
                    throw new Exception("Illegal, no movement in projectile");
                }
                else if (velocity.Y < 0)
                {
                    rotation = 0;
                }
                else if (velocity.Y > 0)
                {
                    rotation = 180;
                }
            }
            else if (velocity.X < 0)
            {
                if (velocity.Y == 0)
                {
                    rotation = 270;
                }
                else if (velocity.Y < 0)
                {
                    rotation = 315;
                }
                else if (velocity.Y > 0)
                {
                    rotation = 225;
                }
            }

            batch.Draw(texture, position, null, Color.White, rotation * (float)Math.PI / 180, new Vector2(texture.Width / 2, texture.Height / 2), 1f, SpriteEffects.None, 0f);
        }
    }


}
