using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Domain.Models.Spawners.Types;
using Sources.Scripts.Infrastructure.Services.ObjectPool;
using Sources.Scripts.InfrastructureInterfaces.Services.ObjectPool;
using Sources.Scripts.Presentations.Views.Common;
using Sources.Scripts.Presentations.Views.NavMeshAgents;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Common;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Base
{
    public abstract class EnemyViewBase : NavMeshAgentBase<EnemyPresenter>, IEnemyViewBase
    {
        [SerializeField] private EnemyHealthView _healthView;
        [SerializeField] private HealthUIText _healthUIText;
        [SerializeField] private EnemyType _enemyType;

        public EnemyHealthView EnemyHealthView => _healthView;
        public EnemyType EnemyType => _enemyType;
        public HealthUIText HealthUIText => _healthUIText;
        
        public ICharacterHealthView PlayerHealthView { get; private set; }

        public override void Destroy()
        {
            DestroyPresenter();
            Hide();
        }
        
        public void SetLookAtPlayer() => 
            transform.LookAt(PlayerHealthView.Position);

        public void SetPlayerHealthView(ICharacterHealthView playerHealthView) =>
            PlayerHealthView = playerHealthView;
    }
}