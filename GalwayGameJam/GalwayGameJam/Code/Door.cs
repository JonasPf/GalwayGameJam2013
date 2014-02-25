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
    public class Door : Entity
    {
        int nextLevel;

        public Door(Texture2D mytexture, Vector2 myposition, int mynextLevel, Game1 mygame)
        {
            position = myposition;
            texture = mytexture;
            nextLevel = mynextLevel;
        }


        public override void onCollide(Entity entity, Game1 game)
        {
            if (entity is Player)
            {
                Boolean allEnemiesKilled = true;
                foreach (Entity e in game.entities)
                {
                    if (e is Enemy)
                    {
                        allEnemiesKilled = false;
                    }
                }

                if (allEnemiesKilled)
                {
                    game.loadLevel(nextLevel);
                }
                else
                {
                    game.showText("The door is still closed!");
                }
            }

            base.onCollide(entity, game);
        }

    }
}