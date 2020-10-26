﻿using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Items
{
    class ScrewAttackItem : IItem
    {
        private ISprite sprite;
        private float xLoc = 0;
        private float yLoc = 0;
        public Rectangle Space { get; set; }

        public ScrewAttackItem(Vector2 initialLocation)
        {
            sprite = ItemSpriteFactory.Instance.ScrewAttackItemSprite(this);
            xLoc = initialLocation.X;
            yLoc = initialLocation.Y;
        }

        public void Update(GameTime gameTime)
        {
            Space = new Rectangle((int)xLoc, (int)yLoc, 16, 16);
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public bool IsDead()
        {
            return false;
        }

        public Rectangle SpaceRectangle()
        {
            return Space;
        }
    }
}
