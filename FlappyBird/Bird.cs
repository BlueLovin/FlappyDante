using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FlappyBird
{
    
    class Bird
    {
        public static int X;
        public static int Y = 0;
        public const int Width = 40;
        public const int Height = 35;

        public Bird()
        {

        }

        //public static void DeathAnimation()
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        if(i < 25)
        //            Y--;
        //        if (i > 25)
        //            Y++;
        //        Thread.Sleep(25);
        //    }
        //}
    }
}
