using System.Collections.Generic;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Infrastructure.Services.ObjectPool;
using Sources.Scripts.InfrastructureInterfaces.Services.ObjectPool;
using Sources.Scripts.Presentations.Views.Common;
using Sources.Scripts.Presentations.Views.NavMeshAgents;
using Sources.Scripts.PresentationsInterfaces.Views.Common;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Players;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Scripts.Presentations.Views.Enemies.Base
{
    public abstract class EnemyViewBase : NavMeshAgentBase<EnemyPresenter>, IEnemyViewBase
    {
        [SerializeField] private EnemyHealthView _healthView;
        [SerializeField] private HealthBarUI _healthBarUI;
        [SerializeField] private HealthUIText _healthUIText;

        private IPoolableObjectDestroyerService _poolableObjectDestroyerService =
            new PoolableObjectDestroyerService();

        public EnemyHealthView EnemyHealthView => _healthView;

        public HealthBarUI HealthBarUI => _healthBarUI;

        public HealthUIText HealthUIText => _healthUIText;
        
        public ICharacterHealthView CharacterHealthView { get; private set; }

        public override void Destroy()
        {
            _poolableObjectDestroyerService.Destroy(this);
            DestroyPresenter();
        }

        public void SetCharacterHealth(ICharacterHealthView characterHealthView) =>
            CharacterHealthView = characterHealthView;

        public void EnableNavmeshAgent() =>
            NavMeshAgent.enabled = true;

        public void DisableNavmeshAgent() =>
            NavMeshAgent.enabled = false;
    }
}