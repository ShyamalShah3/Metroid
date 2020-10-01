﻿using CrossPlatformDesktopProject.Libraries.Command;
using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Nyigel Spann
    class Damage : ICommand
    {
        private PlayerSprite samus;
        private Game1 game;

        public Damage(Game1 game, PlayerSprite player) {
            samus = player;
            this.game = game;
        }
        public void Execute()
        {

        }
    }
}