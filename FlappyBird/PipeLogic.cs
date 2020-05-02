using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    class PipeLogic
    {
		public static void ResetPipe()
		{
			Pipe1.X = 300;
			Pipe1.TopY = setY();
			Pipe1.BottomY = Pipe1.TopY + 650;

			Pipe2.X = 550;
			Pipe2.TopY = setY();
			Pipe2.BottomY = Pipe2.TopY + 650;
		}
		public static void MoveScreen()
		{
			if (!Game1.GameOver)
			{
				Pipe1.X--;
				Pipe2.X--;
				if (Pipe1.X < -97)
				{
					Pipe1.X = 350;
					Pipe1.TopY = setY();
					Pipe1.BottomY = Pipe1.TopY + 650;
				}
				if (Pipe2.X < -97)
				{
					Pipe2.X = 350;
					Pipe2.TopY = setY();
					Pipe2.BottomY = Pipe2.TopY + 650;
				}
			}
		}
		private static int setY()
		{
			Random random = new Random();

			return random.Next(-450, -200);
		}
	}
}
