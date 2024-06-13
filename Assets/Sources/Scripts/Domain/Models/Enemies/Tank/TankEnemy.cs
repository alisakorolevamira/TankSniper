using Sources.Scripts.Domain.Models.Enemies.Base;

namespace Sources.Scripts.Domain.Models.Enemies.Tank
{
    public class TankEnemy : Enemy
    {
        public TankEnemy(
            EnemyHealth enemyHealth,
            EnemyAttacker enemyAttacker)
            : base(
                enemyHealth,
                enemyAttacker)
        {
        }
    }
}