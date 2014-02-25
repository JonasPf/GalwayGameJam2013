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
    class Level_One_Map
    {
        //The Sprites for the Reception Area
        public Texture2D[] reception_Sprites = new Texture2D[5];
        public Vector2[] reception_Object_pos = new Vector2[5];

        Texture2D receptionist;

        public Rectangle receptionRect;
        Rectangle welcomeMatRectangle;
        Rectangle corridorMatRectangle;
        Rectangle benchRectangle;

        public bool exitLevel;

        public Level_One_Map(ContentManager content)
        {
            reception_Sprites[0] = content.Load<Texture2D>("Sprites/receptionDesk");
            reception_Sprites[1] = content.Load<Texture2D>("Sprites/bench");
            reception_Sprites[2] = content.Load<Texture2D>("Sprites/welcomeMat");
            reception_Sprites[3] = content.Load<Texture2D>("Sprites/reception_floor");
            reception_Sprites[4] = content.Load<Texture2D>("Sprites/corridorMat");

            reception_Object_pos[0] = new Vector2(230, 0);
            reception_Object_pos[1] = new Vector2(300, (8 * 80) - 120);
            reception_Object_pos[2] = new Vector2(10, (4 * 80));
            reception_Object_pos[3] = new Vector2(0, 0);
            reception_Object_pos[4] = new Vector2((11 * 80) - 10, (4 * 80));
        }

        public void Update(Vector2 pos)
        {
            welcomeMatRectangle = new Rectangle((int)reception_Object_pos[2].X, (int)reception_Object_pos[2].Y, (int)reception_Sprites[2].Width, (int)reception_Sprites[2].Height);
            corridorMatRectangle = new Rectangle((int)reception_Object_pos[4].X, (int)reception_Object_pos[4].Y, reception_Sprites[4].Width, reception_Sprites[4].Height);
            benchRectangle = new Rectangle((int)reception_Object_pos[1].X, (int)reception_Object_pos[1].Y, reception_Sprites[4].Width, reception_Sprites[4].Height);

            if (Vector2.Distance(pos, reception_Object_pos[4]) < 20)
            {
                exitLevel = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(reception_Sprites[3], reception_Object_pos[3], null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            //spriteBatch.Draw(reception_Sprites[0], reception_Object_pos[0], null, Color.White, 0, new Vector2(reception_Sprites[0].Width/2, reception_Sprites[0].Height/2), 1, SpriteEffects.None, 0);
            //spriteBatch.Draw(reception_Sprites[1], reception_Object_pos[1], null, Color.White, 0, new Vector2(reception_Sprites[1].Width / 2, reception_Sprites[1].Height / 2), 1, SpriteEffects.None, 0);
            spriteBatch.Draw(reception_Sprites[2], reception_Object_pos[2], null, Color.White, (float)Math.PI / 2, new Vector2(reception_Sprites[2].Width / 2, reception_Sprites[2].Height / 2), 1, SpriteEffects.None, 0);
            spriteBatch.Draw(reception_Sprites[4], reception_Object_pos[4], null, Color.White, (float)Math.PI / 2, new Vector2(reception_Sprites[4].Width / 2, reception_Sprites[4].Height / 2), 1, SpriteEffects.None, 0);
            spriteBatch.End();
        }
    }
}
