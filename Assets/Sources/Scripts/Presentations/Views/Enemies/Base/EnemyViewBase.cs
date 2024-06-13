using Sources.Scripts.Controllers.Presenters.Enemies.Base;
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
        [SerializeField] private HealthBarUI _healthBarUI;
        [SerializeField] private HealthUIText _healthUIText;

        private IPoolableObjectDestroyerService _poolableObjectDestroyerService =
            new PoolableObjectDestroyerService();

        public EnemyHealthView EnemyHealthView => _healthView;

        public HealthBarUI HealthBarUI => _healthBarUI;

        public HealthUIText HealthUIText => _healthUIText;
        
        public ICharacterHealthView PlayerHealthView { get; private set; }

        public override void Destroy()
        {
            _poolableObjectDestroyerService.Destroy(this);
            DestroyPresenter();
        }
        
        public void SetLookAtPlayer()
        {
            Quaternion rotation = Camera.main.transform.rotation;
            transform.LookAt(transform.position + rotation * Vector3.back, rotation * Vector3.up);
        }

        public void SetPlayerHealthView(ICharacterHealthView playerHealthView) =>
            PlayerHealthView = playerHealthView;

        public void EnableNavmeshAgent() =>
            NavMeshAgent.enabled = true;

        public void DisableNavmeshAgent() =>
            NavMeshAgent.enabled = false;
    }
}