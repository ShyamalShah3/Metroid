﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.Libraries.Command;
using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;

namespace CrossPlatformDesktopProject.Libraries.Command
{
	class NextEnemy : ICommand
	{
		private Game1 game;

		public NextEnemy(Game1 game)
		{
			this.game = game;
		}

		public void Execute()
		{
			if (game.enemyIndex == game.enemySprites.Count() - 1)
			{
				game.enemyIndex = 0;
			}
			else
			{
				game.enemyIndex += 1;
			}
		}
	}
}