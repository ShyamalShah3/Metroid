﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.Libraries.Sprite;

namespace CrossPlatformDesktopProject.Libraries.SFactory
{
    public interface IFactory
    {
        //Constructor
        public void LoadAllTextures(ContentManager content);

		//Enemies
		public List<ISprite> CreateEnemySpriteList(Vector2 location);

        //Projectiles
		public ISprite CreateBomb(Vector2 location);
		public ISprite CreateMissileRocket(Vector2 location);
		public ISprite CreatePowerBeam(Vector2 location, Vector2 direction, bool isLongBeam);
		public ISprite CreateIceBeam(Vector2 location, Vector2 direction, bool isLongBeam);
		public ISprite CreateWaveBeam(Vector2 location, Vector2 direction, bool isLongBeam, bool isIceBeam);
		public ISprite CreateKraidHorn(Vector2 location, bool isMovingRight);
		public ISprite CreateKraidMissile(Vector2 location, Vector2 direction);
		public ISprite CreatePlayerSprite();


	}
}
