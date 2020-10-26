﻿using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    class EnemyDamagePlayerCommand : ICommand
    {
        private IPlayer player;
        private IEnemy enemy;
        public EnemyDamagePlayerCommand(IPlayer player, IEnemy enemy) {
            this.player = player;
            this.enemy = enemy;
        }
        public void Execute()
        {
            player.TakeDamage(enemy.GetDamage());
        }
    }
}