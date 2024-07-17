using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Infrastructure.Services.InputServices;
using Sources.Scripts.Infrastructure.Services.ObjectPool;
using Sources.Scripts.InfrastructureInterfaces.Services.ObjectPool;
using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Bullets
{
    public class DronBulletView : View, IBulletView
    {
        [SerializeField] private ParticleSystem _onDestroyEffect;
        [SerializeField] private Rigidbody _rigidbody;

        private IPoolableObjectDestroyerService _poolableObjectDestroyerService = 
            new PoolableObjectDestroyerService();
        
        private IWeaponView _weaponView;
        private bool _isDisposed;
        private CancellationTokenSource _cancellationTokenSource;
        private GameplayInputService _inputService;
        private float _horizontal;
        private float _vertical;
        private float _distance = Mathf.Infinity;
        private readonly TimeSpan _delay = TimeSpan.FromMilliseconds(BulletConst.Delay);
        
        public void Construct(IWeaponView weaponView) =>
            _weaponView = weaponView ?? throw new ArgumentNullException(nameof(weaponView));
        
        public void Move(Vector3 direction)
        {
            _cancellationTokenSource = new CancellationTokenSource();

            ChangePosition(_cancellationTokenSource.Token);
            
            _cancellationTokenSource.Cancel();
        }

        private async void ChangePosition(CancellationToken token)
        {
            try
            {
                while (_isDisposed == false)
                {
                    _rigidbody.velocity = transform.forward * 10;

                    await UniTask.Delay(_delay, cancellationToken: token);
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if(_isDisposed)
                return;

            if (collision.gameObject.TryGetComponent(out IEnemyHealthView enemyHealthView))
            {
                _weaponView.DealDamage(enemyHealthView);
                SpawnEffectOnDestroy();
                
                return;
            }
            
            collision.collider.SendMessage("Shatter", collision.transform.position, SendMessageOptions.DontRequireReceiver);
            SpawnEffectOnDestroy();
        }
        
        private void SpawnEffectOnDestroy()
        {
            ParticleSystem effect = Instantiate(_onDestroyEffect, transform.position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, BulletConst.EffectDelay);
            _poolableObjectDestroyerService.Destroy(this);
        }
    }
}