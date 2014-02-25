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
    public abstract class AnimationEntity : Entity
    {

        public AnimatedTexture animation;

        public override void draw(SpriteBatch batch)
        {
            animation.DrawFrame(batch, position);
        }

        public override Rectangle getRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, animation.getWidth(), animation.getHeight());
        }

        public override void update(Game1 game, GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            animation.UpdateFrame(elapsed);

            base.update(game, gameTime);
        }
    }


}
