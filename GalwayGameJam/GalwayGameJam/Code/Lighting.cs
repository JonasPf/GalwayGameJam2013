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
    class Lighting
    {
        public Texture2D blackSquare;
        public Texture2D lightmask;

        public RenderTarget2D mainScene;
        public RenderTarget2D lightMask;

        public Effect lightingEffect;

        public Vector2 light_Pos = new Vector2(200, 200);

        const int LIGHTOFFSET = 115 * 2;

        public Lighting(ContentManager content, GraphicsDevice graphics)
        {
            blackSquare = content.Load<Texture2D>("images/blacksquare");

            lightmask = content.Load<Texture2D>("images/lightmask");

            lightingEffect = content.Load<Effect>("effects/lighting");

            var pp = graphics.PresentationParameters;
            mainScene = new RenderTarget2D(graphics, 2000, 2000);
            lightMask = new RenderTarget2D(graphics, 2000, 2000);
        }

        public void Update(Vector2 pos)
        {
            //Update Position;
            light_Pos = pos;
        }

        private void drawMain(GameTime gameTime, GraphicsDevice graphics, SpriteBatch spriteBatch)
        {

            graphics.SetRenderTarget(mainScene);
            graphics.Clear(Color.Black);

            spriteBatch.Begin();

            // Lay out some ground.

            spriteBatch.End();

            graphics.SetRenderTarget(null);
        }

        private void drawLightMask(GameTime gameTime, GraphicsDevice graphics, SpriteBatch spriteBatch)
        {
            graphics.SetRenderTarget(lightMask);
            graphics.Clear(Color.Black);

            // Create a Black Background
            spriteBatch.Begin();
            spriteBatch.Draw(blackSquare, new Vector2(0, 0), new Rectangle(0, 0, 1800, 1800), Color.White);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);

            // Draw out lightmasks based on torch positions.
            var new_pos = new Vector2(light_Pos.X - LIGHTOFFSET, light_Pos.Y - LIGHTOFFSET);
            spriteBatch.Draw(lightmask, new_pos, null, Color.White, 0, new Vector2(), 2, SpriteEffects.None, 0);
            //spriteBatch.Draw(lightmask, new Vector2(mousePosition.X - LIGHTOFFSET, mousePosition.Y - LIGHTOFFSET), Color.White);

            spriteBatch.End();

            graphics.SetRenderTarget(null);
        }

        public void Draw(GameTime gameTime, GraphicsDevice graphics, SpriteBatch spriteBatch)
        {
            drawLightMask(gameTime, graphics, spriteBatch);

            graphics.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            lightingEffect.Parameters["lightMask"].SetValue(lightMask);
            lightingEffect.CurrentTechnique.Passes[0].Apply();
            spriteBatch.Draw(mainScene, new Vector2(0, 0), Color.White);
            spriteBatch.End();
        }
    }
}
