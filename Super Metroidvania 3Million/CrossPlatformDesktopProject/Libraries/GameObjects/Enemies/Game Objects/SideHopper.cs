﻿using SuperMetroidvania5Million.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using SuperMetroidvania5Million.Libraries.Container;


namespace SuperMetroidvania5Million.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class SideHopper : IEnemy
    {
        public Rectangle Space { get; set; }
        private ISprite sprite;
        private bool isDead;
        private EnemyStateMachine stateMachine;
        private int horizSpeed, vertSpeed;
        private float initialY;
        private int health;
        public bool damaged;
        public bool frozen;
        private EnemyUtilities EnemyUtilities = InfoContainer.Instance.Enemies;



        public SideHopper(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.SideHopperSprite(this);
            stateMachine = new EnemyStateMachine(location);
            horizSpeed = 3;
            vertSpeed = 0;
            initialY = location.Y;
            health = EnemyUtilities.EnemyHealth;
            damaged = false;
            frozen = false;

        }

        public void Update(GameTime gameTime)
        {
            stateMachine.Update();
            Space = new Rectangle((int)stateMachine.x, (int)stateMachine.y, EnemyUtilities.SidehopperWidth, EnemyUtilities.SidehopperHeight);
            sprite.Update(gameTime);
        }
      
        public void Jump(float count, int direction)
        {
            float a = EnemyUtilities.SidehopperJumpA;
            float b = EnemyUtilities.SidehopperJumpB;
            float c = EnemyUtilities.SidehopperJumpC;

            stateMachine.y = a * (count * count) - b * count + initialY + c;
            stateMachine.x += direction;
        }

        public Rectangle SpaceRectangle()
        {
            return Space;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public Boolean IsDead()
        {
            return isDead;
        }

        public void Kill()
        {
            isDead = true;
            stateMachine.Kill();
        }

        public void MoveLeft()
        {
            stateMachine.MoveLeft(horizSpeed);
        }
        public void MoveRight()
        {
            stateMachine.MoveRight(horizSpeed);
        }
        public void MoveUp()
        {
            stateMachine.MoveUp(vertSpeed);
        }
        public void MoveDown()
        {
            stateMachine.MoveDown(vertSpeed);
        }
        public void ChangeDirection()
        {
            stateMachine.changeDirection();
        }
        public void Freeze()
        {
            frozen = true;
            stateMachine.Freeze();
        }
        public void StopMoving()
        {
            stateMachine.StopMoving();
        }
        public int GetDamage()
        {
            return EnemyUtilities.EnemyDamage;
        }
        public void TakeDamage(int damage)
        {
            health = health - damage;
            damaged = true;
            if (health <= 0)
            {
                this.Kill();
            }
        }
    }
}
