using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CrossPlatformDesktopProject.Libraries.SFactory;
using CrossPlatformDesktopProject.Libraries.Controller;
using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.Sprite.Player;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Player
{
	/*Author: Shyamal Shah*/
	public class LeftWalkSamusState : IPlayerState 
	{
		private Samus samus;
		private ISprite sprite;
		private Vector2 missileLoc;
		private Vector2 direction;

		public LeftWalkSamusState(Samus sam)
		{
			samus = sam;
			sprite = PlayerSpriteFactory.Instance.LeftWalkSprite(samus);
			missileLoc = new Vector2(samus.x + 19, samus.y + 32);
			direction = new Vector2(-4.0f, 0.0f);
			samus.Jumping = false;
			
		}

		public void Attack()
        {
			missileLoc = new Vector2(samus.x, samus.y + 16);
			if (samus.missile == 0)
			{
				GameObjectContainer.Instance.Add(ProjectilesGOFactory.Instance.CreateMissileRocket(missileLoc, direction));
			}
			else if (samus.missile == 0)
			{
				GameObjectContainer.Instance.Add(ProjectilesGOFactory.Instance.CreatePowerBeam(missileLoc, direction, samus.inventory.HasLongBeam, samus.inventory.HasIceBeam));
			}
			else
			{
				GameObjectContainer.Instance.Add(ProjectilesGOFactory.Instance.CreateWaveBeam(missileLoc, direction, samus.inventory.HasLongBeam));
			}

		}
		public void Jump()
        {
			samus.State = new JumpLeftSamusState(samus);
        }

		public void Morph()
        {
			samus.State = new MorphSamusState(samus);
		}

		public void MoveRight()
        {
			samus.State = new RightIdleSamusState(samus);
		}

		public void MoveLeft()
        {
			//Do nothing
		}

		public void AimUp()
        {
			samus.State = new AimUpSamusState(samus, false);
		}

		public void Update(GameTime gameTime)
		{
			sprite.Update(gameTime);
			samus.Physics.MoveLeft();
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			sprite.Draw(spriteBatch);
		}

		public void Idle () 
		{
			samus.State = new LeftIdleSamusState(samus);
		}
	}
}
