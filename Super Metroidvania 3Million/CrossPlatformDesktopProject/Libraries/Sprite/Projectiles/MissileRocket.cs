﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    public class MissleRocket : IProjectile
    {
        public Vector2 Location { get; set; }
        public Vector2 Direction { get; set; }
        public int Damage { get; set; }

        private Texture2D texture;
        private bool isHorizontal;
        private bool isDead = false;
        


        public MissleRocket(Texture2D texture, Vector2 initialLocation, Vector2 direction)
        {
            isHorizontal = (int) direction.Y == 0;
            this.texture = texture;
            Location = initialLocation;
            Direction = direction;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            if (isDead) { //Rocket has collided, explosion animation.
                
                
            }
            else { //Rocket still flying
                Rectangle destinationRec = new Rectangle((int)Location.X, (int)Location.Y, 16, 8);
                Rectangle sourceRec = new Rectangle(0, 4, 16, 8); //Horizontal texture before collision
                if (!isHorizontal)
                {
                    destinationRec = new Rectangle((int)Location.X, (int)Location.Y, 8, 16);
                    sourceRec = new Rectangle(17, 0, 8, 16); //Vertical texture before collision
                }
                spriteBatch.Draw(texture, destinationRec, sourceRec, Color.White); 
            }

            
        }

        public void Update(GameTime gameTime)
        {

            //Update position
            Location = Vector2.Add(Location, Direction);

            //Using temporary var til collisions are added
            bool collision = false;

            //Die if a collision occurs or the projectile leaves the screen
            isDead = collision || Location.X > 800 || Location.X < 0 || Location.Y > 480 || Location.Y < 0;

        }

        public bool IsDead() {
            return isDead;
        }
    }
}
