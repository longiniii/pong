using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace pong
{
    internal static class SoundEffects
    {
        public static SoundPlayer WinningAudio { get; private set; } = new SoundPlayer("C:\\Users\\User\\Documents\\my projects\\c#\\pong\\pong\\AudioFiles\\WinningAudio.wav");
        public static SoundPlayer LosingAudio { get; private set; } = new SoundPlayer("C:\\Users\\User\\Documents\\my projects\\c#\\pong\\pong\\AudioFiles\\LosingAudio.wav");

    }
}
