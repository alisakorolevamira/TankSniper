using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Doozy.Runtime.Signals;
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
        private readonly TimeSpan _delay = TimeSpan.FromMilliseconds(BulletConst.Delay);
        
        public void Construct(IWeaponView weaponView) =>
            _weaponView = weaponView ?? throw new ArgumentNullException(nameof(weaponView));

        public void SetInput(GameplayInputService inputService)
        {
            _inputService = inputService;
            _inputService.RotationInputReceived += Rotate;
        }

        private void Rotate(Vector2 delta)
        {
            _vertical -= 2 * delta.y * Time.deltaTime;
            _horizontal += 2 * delta.x * Time.deltaTime;
            
            _vertical = Mathf.Clamp(_vertical, CameraConst.MinVerticalAngle, CameraConst.MaxVerticalAngle);
            _horizontal = Mathf.Clamp(_horizontal, CameraConst.MinHorizontalAngle, CameraConst.MaxHorizontalAngle);

            Vector3 rotation = new Vector3(_vertical, _horizontal, 0);
            
            SetRotation(rotation);
        }
        
        public void Move(Vector3 direction)
        {
            ChangePosition();
        }

        private async void ChangePosition()
        {
            try
            {
                while (_isDisposed == false)
                {
                    var forward = transform.forward;
                    _rigidbody.velocity = new Vector3(forward.x, forward.y, forward.z) * 3.5f;

                    await UniTask.Delay(_delay);
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
            _inputService.RotationInputReceived -= Rotate;
            
            ParticleSystem effect = Instantiate(_onDestroyEffect, transform.position, Quaternion.identity);
            
            Signal.Send(StreamId.Gameplay.ReturnToHud);
            effect.Play();
            Destroy(effect.gameObject, BulletConst.EffectDelay);
            _poolableObjectDestroyerService.Destroy(this);
        }
    }
}