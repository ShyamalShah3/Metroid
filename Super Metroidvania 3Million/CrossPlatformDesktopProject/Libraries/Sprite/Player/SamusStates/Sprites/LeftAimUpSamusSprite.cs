using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CrossPlatformDesktopProject.Libraries.SFactory;
using CrossPlatformDesktopProject.Libraries.Controller;
using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.Sprite.Player;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Player
{
	/*Author: Shyamal Shah*/
	public class LeftAimUpSamusSprite : ISprite
	{
		public Texture2D texture { get; set; }
		private int rows;
		private int columns;
		private Samus samus;

		public LeftAimUpSamusSprite(Texture2D text, Samus sus)
        {
			texture = text;
			samus = sus;
			rows = 1;
			columns = 1;
        }

		public void Update(GameTime gameTime)
        {
			//Nothing needs to be updated
        }

		public void Draw(SpriteBatch spriteBatch)
        {
			int width = texture.Width / columns;
			int height = texture.Height / rows;
			int row = 0;
			int column = 0;

			Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
			samus.space = new Rectangle(samus.space.X, samus.space.Y, width, height);
			spriteBatch.Draw(texture, samus.space, sourceRectangle, Color.White);
			samus.space = new Rectangle(samus.space.X, samus.space.Y, 64, 64);
		}
	}
}
