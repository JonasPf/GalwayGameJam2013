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
    public class SolidObject : Entity
    {
        public SolidObject(Texture2D mytexture, Vector2 myposition)
        {
            position = myposition;
            texture = mytexture;
        }
    }
}
