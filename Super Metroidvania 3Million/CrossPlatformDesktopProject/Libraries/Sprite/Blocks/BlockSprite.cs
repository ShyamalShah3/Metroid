﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Blocks
{
    class BlockSprite : BlockInterface
    {
        private Texture2D Texture;
        private int xPos = 0;
        private int yPos = 0;
        private bool isDead = false;

        public BlockSprite(Texture2D Texture, Vector2 location)
        {
            this.Texture = Texture;
            this.xPos = (int)location.X;
            this.yPos = (int)location.Y;
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width;
            int height = Texture.Height;

            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = new Rectangle(xPos, yPos, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);;
        }

        public bool IsDead() {
            return false;
        }

        
    }
}