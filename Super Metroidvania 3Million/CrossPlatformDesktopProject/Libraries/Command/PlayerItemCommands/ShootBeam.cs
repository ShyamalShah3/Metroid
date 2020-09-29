﻿using CrossPlatformDesktopProject.Command;
using CrossPlatformDesktopProject.Sprite.Player_Sprites;
using CrossPlatformDesktopProject.SpriteFactory;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerItemCommands
{
    //Author: Nyigel Spann
    class ShootBeam : ICommand
    {
        private PlayerSprite samus;
        private IFactory factory;
        private float speed = 1;

        public ShootBeam(PlayerSprite player, IFactory factory) {
            samus = player;
            this.factory = factory;
        }
        public void Execute()
        {
            Vector2 direction = new Vector2(speed, 0);
            if (!samus.facingRight)
            {
                direction = new Vector2(-speed, 0);
            }
            Vector2 location = new Vector2(samus.Location.X, samus.Location.Y);
            if (samus.wave)
            {
                factory.CreateWaveBeam(location, direction, samus.elong, samus.ice);
            }
            else if (samus.ice)
            {
                factory.CreateIceBeam(location, direction, samus.elong);
            }
            else { //Power beam
                factory.CreatePowerBeam(location, direction, samus.elong);
            } 
            
            
        }
    }
}
