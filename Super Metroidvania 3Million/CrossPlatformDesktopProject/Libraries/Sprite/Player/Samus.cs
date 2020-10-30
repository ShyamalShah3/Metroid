﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using CrossPlatformDesktopProject.Libraries.Sprite.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Player
{
    public class Samus : IPlayer
    {
        public IPlayerState state;
        public PlayerInventory inventory { get; set; }
        public int health;
        public Rectangle space { get; set; }
        private Game1 game;
        private bool isDead;
        public int missile;
        public GameTime gameTime;
        public PlayerPhysics Physics { get; private set; }
        public bool Jumping { get; set; }
        public float x { get; set; }
        public float y { get; set; }

        public Samus(Vector2 l, Game1 g, GameTime g2)
		{
            gameTime = g2;
            game = g;
            health = 100;
            isDead = false;
            x = l.X;
            y = l.Y;
            space = new Rectangle((int) x, (int) y, 64, 64);
            missile = 0;
            inventory = new PlayerInventory(30);
            Physics = new PlayerPhysics(this);
			state = new RightIdleSamusState(this);
            Jumping = false;
            
        }

        public void Attack()
        {
            state.Attack();
        }
        public void CycleBeamMissile()
        {
            if (missile == 2)
            {
                missile = 0;
            }else
            {
                missile++;
            }
        }
        public void Jump()
        {
            state.Jump();
        }
        public void Morph()
        {
            state.Morph();
        }
        public void MoveRight()
        {
            state.MoveRight();
        }
        public void MoveLeft()
        {
            state.MoveLeft();
        }
        public void AimUp()
        {
            state.AimUp();
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                health = 0;
                isDead = true;
            }
        }
        public void Upgrade(IItem item)
        {
            inventory.GiveItem(item);
        }

        public void Update(GameTime gameTime)
        {
            state.Update(gameTime);
            Physics.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }

        public bool IsDead()
        {
            return isDead;
        }

        public void Idle() { 
            state.Idle();
        }

        public void Kill()
        {
            isDead = true;
        }

        public Rectangle SpaceRectangle()
        {
            return space;
        }

        public void UpdateLocation(Vector2 l)
        {
            x = l.X;
            y = l.Y;
            space = new Rectangle((int)x, (int)y, 64, 64);
        }
    }
}
