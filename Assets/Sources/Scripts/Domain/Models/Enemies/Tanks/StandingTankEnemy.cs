using Sources.Scripts.Domain.Models.Enemies.Base;

namespace Sources.Scripts.Domain.Models.Enemies.Tanks
{
    public class StandingTankEnemy : Enemy
    {
        public StandingTankEnemy(
            EnemyHealth enemyHealth,
            EnemyAttacker enemyAttacker)
            : base(
                enemyHealth,
                enemyAttacker)
        {
        }
    }
}