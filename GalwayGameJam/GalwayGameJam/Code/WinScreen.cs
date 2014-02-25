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
    public class WinScreen : Entity
    {
        public WinScreen(Texture2D mytexture)
        {
            position = new Vector2(0, 0);
            texture = mytexture;
        }

        public override void update(Game1 game, GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.R))
            {
                game.loadLevel(0);
            }

            base.update(game, gameTime);
        }
    }
}
