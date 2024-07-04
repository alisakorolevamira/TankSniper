using Sources.Scripts.Domain.Models.Enemies.Base;

namespace Sources.Scripts.Domain.Models.Enemies.Boss
{
    public class BossEnemy : Enemy
    {
        public BossEnemy(
            EnemyHealth enemyHealth,
            EnemyAttacker enemyAttacker)
            : base(
                enemyHealth,
                enemyAttacker)
        {
        }
    }
}