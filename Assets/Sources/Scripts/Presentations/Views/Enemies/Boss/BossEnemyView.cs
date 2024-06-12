using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Boss
{
    public class BossEnemyView : EnemyViewBase, IBossEnemyView
    {
        [SerializeField] private BossEnemyAnimation _bossEnemyAnimation;
        [SerializeField] private ParticleSystem _massAttackParticle;

        public BossEnemyAnimation BossEnemyAnimation => _bossEnemyAnimation;

        public void PlayAttackParticle() =>
            _massAttackParticle.Play();

        public void SetAgentSpeed(float speed) =>
            NavMeshAgent.speed = speed;

        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}