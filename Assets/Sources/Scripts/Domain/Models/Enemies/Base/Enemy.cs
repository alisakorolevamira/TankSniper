using System;
using Sources.Scripts.Domain.Models.Spawners.Types;

namespace Sources.Scripts.Domain.Models.Enemies.Base
{
    public class Enemy
    {
        public Enemy(
            EnemyHealth enemyHealth,
            EnemyAttacker enemyAttacker,
            EnemyType enemyType)
        {
            EnemyHealth = enemyHealth ?? throw new ArgumentNullException(nameof(enemyHealth));
            EnemyAttacker = enemyAttacker;
            EnemyType = enemyType;
        }

        public bool IsInitialized { get; set; }
        public EnemyType EnemyType { get; private set; }

        public EnemyHealth EnemyHealth { get; set; }

        public EnemyAttacker EnemyAttacker { get; }
    }
}