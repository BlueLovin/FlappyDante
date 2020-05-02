using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    class Pipe2
    {
        public static int X = 450;
        public static int TopY = -350;
        public static int BottomY = TopY + 650;
        public const int Width = 97;//for collision purposes

        public Pipe2(int XVal, int BtmY, int TopYval)
        {
            BottomY = BtmY;
            TopY = TopYval;
            X = XVal;
        }
    }
}