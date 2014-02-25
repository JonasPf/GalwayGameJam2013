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
    class Level_Two_Map
    {
        Texture2D beds;
        Vector2[] beds_pos = new Vector2[3];

        public Level_Two_Map(ContentManager content)
        {
            beds = content.Load<Texture2D>("Sprites/bed");
            beds_pos[0] = new Vector2(400, 100);
            beds_pos[1] = new Vector2(50, 500);
            beds_pos[2] = new Vector2(400, 400);
        }

        public void Update()
        {
 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(beds, beds_pos[0], null, Color.White, 0, new Vector2(), 1, SpriteEffects.None, 0);
            spriteBatch.Draw(beds, beds_pos[1], null, Color.White, 0, new Vector2(), 1, SpriteEffects.None, 0);
            spriteBatch.Draw(beds, beds_pos[2], null, Color.White, 0, new Vector2(), 1, SpriteEffects.None, 0);
        }
    }
}
