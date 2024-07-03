using Sources.Scripts.Domain.Models.Enemies.Base;

namespace Sources.Scripts.Domain.Models.Enemies.Jeep
{
    public class JeepEnemy : Enemy
    {
        public JeepEnemy(
            EnemyHealth enemyHealth,
            EnemyAttacker enemyAttacker)
            : base(
                enemyHealth,
                enemyAttacker)
        {
        }
    }
}