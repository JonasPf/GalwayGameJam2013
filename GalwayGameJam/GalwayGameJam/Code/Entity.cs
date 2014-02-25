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
    public abstract class Entity
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 velocity;
        public int width;
        public int height;

        public virtual void update(Game1 game, GameTime gameTime)
        {
            position.X += velocity.X;
            position.Y += velocity.Y;
        }

        public virtual void draw(SpriteBatch batch)
        {
            // Origin: new Vector2(texture.Width / 2, texture.Height / 2)
            batch.Draw(texture, position, null, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        public int getWidth()
        {
            return texture.Width;
        }

        public int getHeight()
        {
            return texture.Height;
        }

        public virtual Rectangle getRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public virtual void onCollide(Entity entity, Game1 game)
        {

        }

        public void checkCollision(Entity entity, Game1 game)
        {
            if (entity.getRectangle().Intersects(getRectangle()))
            {
                onCollide(entity, game);
            }
        }

        public Boolean testCollision(Rectangle rect)
        {
            return getRectangle().Intersects(rect);
        }
    }

}
