using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Domain.Models.Spawners.Types;

namespace Sources.Scripts.Domain.Models.Enemies.Boss
{
    public class BossEnemy : Enemy
    {
        public BossEnemy(
            EnemyHealth enemyHealth,
            EnemyAttacker enemyAttacker,
            EnemyType enemyType,
            float stunTime,
            float walkSpeed,
            float runSpeed)
            : base(
                enemyHealth,
                enemyAttacker,
                enemyType)
        {
            StunTime = stunTime;
            WalkSpeed = walkSpeed;
            RunSpeed = runSpeed;
        }

        public float StunTime { get; }

        public float WalkSpeed { get; }

        public float RunSpeed { get; }

        public bool IsRun { get; set; }
    }
}