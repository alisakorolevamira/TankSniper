using System;
using Sources.Scripts.Infrastructure.Services.ObjectPool;
using Sources.Scripts.InfrastructureInterfaces.Services.ObjectPool;
using Sources.Scripts.Presentations.Triggers;
using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Bullets
{
    public class BulletView : View, IBulletView
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private ParticleSystem _onDestroyEffect;

        private IPoolableObjectDestroyerService _poolableObjectDestroyerService = 
            new PoolableObjectDestroyerService();
        
        private IWeaponView _weaponView;
        private bool _isDisposed;

        public Rigidbody Rigidbody => _rigidbody;
        
        private void OnParticleSystemStopped() =>
            _poolableObjectDestroyerService.Destroy(this);

        public void Construct(IWeaponView weaponView) =>
            _weaponView = weaponView ?? throw new ArgumentNullException(nameof(weaponView));
        
        private void OnCollisionEnter(Collision collision)
        {
            if(_isDisposed)
                return;

            if (collision.gameObject.TryGetComponent(out ITankEnemyView enemyHealthView))
            {
                //_weaponView.DealDamage(enemyHealthView);
                SpawnEffectOnDestroy();
                //DisposeBullet();
            }
        }
        
        private void SpawnEffectOnDestroy()
        {
            if (_onDestroyEffect == false)
                return;

            //var effect = Instantiate(_onDestroyEffect, transform.position, Quaternion.identity);
            _onDestroyEffect.Play();
            
            //Destroy(_onDestroyEffect.gameObject, _effectDestroyLifetime);
        }
    }
}