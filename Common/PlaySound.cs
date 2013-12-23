using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;

namespace Common
{
    public class PlaySound
    {
        public static void Play(byte[] buf)
        {
            MemoryStream ms = new MemoryStream(buf);
            SoundPlayer sp = new SoundPlayer(ms);
            sp.Play();
        }
    }
}
