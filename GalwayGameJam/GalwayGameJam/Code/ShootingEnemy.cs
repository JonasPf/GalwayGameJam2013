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
    public class ShootingEnemy : Enemy
    {
        Vector2 shootdirection;
        public float shootSpeed = 25;
        public float shootCounter;

        public ShootingEnemy(Texture2D mytexture, Game1 game, Vector2 myposition, Vector2 myshootdirection) : base(mytexture, game, myposition)
        {
            position = myposition;
            texture = mytexture;
            shootdirection = myshootdirection;
        }

        public override void update(Game1 game, GameTime gameTime)
        {
            shootCounter++;

            if (shootCounter > shootSpeed) {
                Vector2 projectilePosition = position;
                projectilePosition.X += texture.Width / 2;
                projectilePosition.Y += texture.Height / 2;
                game.entities.Add(new Projectile(game, projectilePosition, shootdirection, this));
                shootCounter = 0;
            }
        }

    }
}
