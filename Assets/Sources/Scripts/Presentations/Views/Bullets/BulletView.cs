using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Infrastructure.Services.ObjectPool;
using Sources.Scripts.InfrastructureInterfaces.Services.ObjectPool;
using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Bullets
{
    public class BulletView : View, IBulletView
    {
        [SerializeField] private ParticleSystem _onDestroyEffect;

        private IPoolableObjectDestroyerService _poolableObjectDestroyerService = 
            new PoolableObjectDestroyerService();
        
        private IWeaponView _weaponView;
        private CancellationTokenSource _cancellationTokenSource;
        private float _distance = Mathf.Infinity;
        private readonly TimeSpan _delay = TimeSpan.FromMilliseconds(BulletConst.Delay);

        public void Construct(IWeaponView weaponView) =>
            _weaponView = weaponView ?? throw new ArgumentNullException(nameof(weaponView));

        public void Move(Vector3 direction)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            Ray ray = new Ray(transform.position, direction);

            if (Physics.Raycast(ray, out RaycastHit hit, _distance))
            {
                Vector3 endPoint = hit.point;

                ChangePosition(endPoint, _cancellationTokenSource.Token);
            }
            
            _cancellationTokenSource.Cancel();
        }

        private async void ChangePosition(Vector3 endPoint, CancellationToken token)
        {
            float step =  BulletConst.Step * Time.deltaTime;
            
            try
            {
                while (Vector3.Distance(transform.position, endPoint) > BulletConst.MinDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, endPoint, step);

                    await UniTask.Delay(_delay, cancellationToken: token);
                }
                
                SpawnEffectOnDestroy();
            }
            catch (OperationCanceledException)
            {
            }
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IEnemyHealthView enemyHealthView))
            {
                _weaponView.DealDamage(enemyHealthView);
                SpawnEffectOnDestroy();
                
                return;
            }
            
            collision.collider.SendMessage("Shatter", collision.transform.position, SendMessageOptions.DontRequireReceiver);
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