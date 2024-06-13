using System;
using Sources.Scripts.Infrastructure.Services.ObjectPool;
using Sources.Scripts.InfrastructureInterfaces.Services.ObjectPool;
using Sources.Scripts.Presentations.Triggers;
using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Scripts.Presentations.Views.Bullets
{
    public class BulletView : View, IBulletView
    {
        [SerializeField] private EnemyHealthParticleCollision _enemyHealthParticleCollision;

        private IPoolableObjectDestroyerService _poolableObjectDestroyerService = 
            new PoolableObjectDestroyerService();
        
        private IWeaponView _weaponView;
        
        private void OnEnable() =>
            _enemyHealthParticleCollision.Entered += OnEntered;

        private void OnDisable() =>
            _enemyHealthParticleCollision.Entered -= OnEntered;
        
        private void OnParticleSystemStopped() =>
            _poolableObjectDestroyerService.Destroy(this);

        public void Construct(IWeaponView weaponView) =>
            _weaponView = weaponView ?? throw new ArgumentNullException(nameof(weaponView));

        private void OnEntered(IEnemyHealthView enemyHealthView) =>
            _weaponView.DealDamage(enemyHealthView);
    }
}