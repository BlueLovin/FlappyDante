using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlappyBird
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		Texture2D pipe;
		Texture2D birdTexture;
		Texture2D GameOverTexture;

		static int velocity;
		static int jumpSpeed = 10;
		bool hasJumped = false;

		public static bool GameOver;

		static KeyboardState OldKeyState;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			graphics.PreferredBackBufferWidth = 250;
			graphics.PreferredBackBufferHeight = 500;
			IsMouseVisible = true;
		}
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
			base.Initialize();
		}

		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			pipe = Content.Load<Texture2D>("pipe");
			birdTexture = Content.Load<Texture2D>("bird");
			GameOverTexture = Content.Load<Texture2D>("gameover");
		}
		protected override void UnloadContent()
		{
		}
		private static bool collision()
		{
			if (Bird.X > (Pipe1.X - Bird.Width) 
				&& Bird.Y > Pipe1.BottomY - Bird.Height 
				&& Bird.X < Pipe1.X + Pipe1.Width
				|| Bird.X > (Pipe2.X - Bird.Width)
				&& Bird.Y > Pipe2.BottomY - Bird.Height
				&& Bird.X < Pipe2.X + Pipe2.Width
				|| Bird.X > (Pipe1.X - Bird.Width)
				&& Bird.Y < Pipe1.TopY + 500
				&& Bird.X < Pipe1.X + Pipe1.Width
				|| Bird.X > (Pipe2.X - Bird.Width)
				&& Bird.Y < Pipe2.TopY + 500
				&& Bird.X < Pipe2.X + Pipe2.Width)
			{
				GameOver = true;
				return true;
			}
			else
			{
				return false;
			}
		}
		
		protected override void Update(GameTime gameTime)
		{

			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			KeyboardState NewKeyboardState = Keyboard.GetState();
			if (!GameOver)
			{
				PipeLogic.MoveScreen();
				base.Window.Title = "x = " + Bird.X + " y = " + Bird.Y;
				var ms = Mouse.GetState();
				#region JUMPcontrols
				if (!collision() && NewKeyboardState.IsKeyUp(Keys.Space) 
					|| NewKeyboardState.IsKeyDown(Keys.Space) 
					&& OldKeyState.IsKeyDown(Keys.Space))
				{
					Bird.X = 50;
					Bird.Y += velocity / 6;
				}
				if (NewKeyboardState.IsKeyDown(Keys.Space)
					&& OldKeyState.IsKeyUp(Keys.Space)
					&& Bird.Y > 0)
				{
					Bird.Y -= jumpSpeed;
					velocity = 5;
					hasJumped = true;
					jumpSpeed = 0;
				}
				if (jumpSpeed < 10 && hasJumped)
				{
					jumpSpeed++;
					Bird.Y -= 8;
					if (jumpSpeed == 9)
						hasJumped = false;
				}

				if (velocity < 50)
				{
					velocity++;
				}
				#endregion
				if (Bird.Y > 500)
				{
					GameOver = true;
				}
				// TODO: Add your update logic here
				OldKeyState = NewKeyboardState;
				base.Update(gameTime);
			}
			if (GameOver)
			{
				KeyboardState ks = Keyboard.GetState();
				if (ks.IsKeyDown(Keys.Enter))
				{
					PipeLogic.ResetPipe();
					ResetGame();
				}
			}
		}

		private void ResetGame()
		{
			Bird.Y = 100;
			velocity = 0;
			jumpSpeed = 0;
			hasJumped = false;
			GameOver = false;
		}
		protected override void Draw(GameTime gameTime)
		{
			spriteBatch.Begin();

			if (!GameOver)
			{
				GraphicsDevice.Clear(Color.CornflowerBlue);

				spriteBatch.Draw(pipe, new Vector2(Pipe1.X, Pipe1.BottomY), Color.White);//PIPE 1 ///BOTTOM PIPES///
				spriteBatch.Draw(pipe, new Vector2(Pipe2.X, Pipe2.BottomY), Color.White);//PIPE 2 //////////////////

				spriteBatch.Draw(pipe, new Vector2(Pipe1.X, Pipe1.TopY), Color.White);//PIPE 1 ///TOP PIPES///
				spriteBatch.Draw(pipe, new Vector2(Pipe2.X, Pipe2.TopY), Color.White);//PIPE 2 ///////////////


				spriteBatch.Draw(birdTexture, new Vector2(Bird.X, Bird.Y), Color.White);//PLAYER

			}
			else if (GameOver)
			{
				spriteBatch.Draw(GameOverTexture, new Vector2(0, 0), Color.White);
			}
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
