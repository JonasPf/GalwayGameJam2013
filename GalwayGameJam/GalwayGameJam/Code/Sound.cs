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
    class Sound
    {
        Song being_Chased;
        Song reception;
        Song asylum;

        public bool play_Chased;
        public bool play_reception;
        public bool play_asylum;

        public Sound(ContentManager content)
        {
            being_Chased = content.Load<Song>("Sound/being chased");
            reception = content.Load<Song>("Sound/reception");
            asylum = content.Load<Song>("Sound/the asylum awaits");
        }

        public void Update()
        {
            if (play_Chased)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(being_Chased);
                play_Chased = false;
            }

            if (play_reception)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(reception);
                play_reception = false;
            }

            if (play_asylum)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(asylum);
                play_asylum = false;
            }

            MediaPlayer.IsRepeating = true;
        }
    }
}