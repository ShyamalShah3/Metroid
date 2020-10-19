﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class Skree : IEnemy
    {

        public Texture2D Texture { get; set; }
        private int Rows;
        private int Columns;
        private int currentFrame;
        private int totalFrames;
        private float x, y, initialY;
        private int count;

        public Skree(Texture2D texture, Vector2 location)
        {
            Texture = texture;
            Rows = 2;
            Columns = 3;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            x = location.X;
            y = location.Y;
            initialY = location.Y;
            count = 0;
        }

        public void Update(GameTime gameTime)
        {
            //change the frame after 10 counts
            if (count == 10)
            {
                count = 0;
                currentFrame++;
                if (currentFrame == 3)
                {
                    currentFrame = 0;
                }
            }
            count++;

            //Move to the ground (410) and then reset
            y += 2;
            if (y > 410-Texture.Height)
            {
                y = initialY;
            }
        }

        
        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)x, (int)y, width*2, height*2);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
        public Boolean IsDead()
        {
            return false;
        }

    }
}
