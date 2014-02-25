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
    public class Flash : Entity
    {
        int flashTimer;
        int flashMaxTimer = 5;
        int endTimer;
        
        Boolean show;

        public Flash(Texture2D mytexture)
        {
            position = new Vector2(0, 0);
            texture = mytexture;
            show = false;
            flashTimer = 0;
        }

        public override void update(Game1 game, GameTime gameTime)
        {
            flashTimer++;
            endTimer++;

            if (endTimer > 250)
            {
                game.loadLevel(4);
            }
            else if (endTimer > 200)
            {
                show = true;
            }
            else if (flashTimer > flashMaxTimer)
            {
                flashTimer = 0;
                show = !show;
            }

        }

        public override void draw(SpriteBatch batch)
        {
            if (show)
            {
                batch.Draw(texture, position, null, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
        }
    }

}
