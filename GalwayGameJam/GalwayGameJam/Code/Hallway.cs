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
    class Hallway
    {
        Texture2D black;
        Rectangle rec;

        Texture2D hallway;

        public Hallway(ContentManager content)
        {
            hallway = content.Load<Texture2D>("Sprites/Corridor floor");
            black = content.Load<Texture2D>("Sprites/black");
        }

        public void Update()
        {
            rec = new Rectangle(0, 0, 1000, 1000);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(black, Vector2.Zero, rec, Color.White);
            spriteBatch.Draw(hallway, new Vector2(0, 400), Color.White);
        }
    }
}
