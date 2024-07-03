using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Domain.Models.Spawners.Types;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.Presentations.Views.NavMeshAgents;
using Sources.Scripts.PresentationsInterfaces.Views.Common;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Boss
{
    public class BossEnemyView : NavMeshAgentBase<EnemyPresenter>, IBossEnemyView
    {
        [SerializeField] private BossEnemyAnimation _bossEnemyAnimation;
        [SerializeField] private ParticleSystem _massAttackParticle;

        public BossEnemyAnimation BossEnemyAnimation => _bossEnemyAnimation;

        public void PlayAttackParticle() =>
            _massAttackParticle.Play();
        
        public ICharacterHealthView PlayerHealthView { get; }
        public void SetPlayerHealthView(ICharacterHealthView playerHealthView)
        {
            
        }

        public void SetLookAtPlayer()
        {
            
        }
    }
}