﻿using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Blocks
{
    class OrangeDoorBlock : IBlock
    {
        public Vector2 Location { get; set; }
        public Rectangle Space { get; set; }

        ISprite sprite;
        private Vector2 initialLocation;
        private bool isDead = false;


        public OrangeDoorBlock(Vector2 initialLocation)
        {
            this.initialLocation = initialLocation;
            Location = initialLocation;
            Space = new Rectangle((int)Location.X, (int)Location.Y, 32, 32);
            sprite = BlockSpriteFactory.Instance.CreateOrangeDoorBlockSprite(this);

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            sprite.Draw(spriteBatch);

        }

        public void Update(GameTime gameTime)
        {

            //Update position and space
            Space = new Rectangle((int)Location.X, (int)Location.Y, Space.Width, Space.Height);
            sprite.Update(gameTime);
        }

        public Rectangle SpaceRectangle()
        {
            return Space;
        }

        public bool IsDead()
        {
            return isDead;
        }

        public void Kill()
        {
            isDead = true;
        }
    }
}