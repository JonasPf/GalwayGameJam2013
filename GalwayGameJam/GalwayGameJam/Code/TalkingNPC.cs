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
    public class TalkingNPC : Entity
    {
        String text;
        Game1 game;

        public TalkingNPC(Texture2D mytexture, Vector2 myposition, String mytext, Game1 mygame)
        {
            position = myposition;
            texture = mytexture;
            text = mytext;
            game = mygame;
        }

        public override void onCollide(Entity entity, Game1 game)
        {
            if (entity is Player)
            {
                game.showText(text);
                //game.entities.Remove(this);
            }
        }

    }
}
