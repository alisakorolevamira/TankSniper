using System;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Bullets;
using Sources.Scripts.InfrastructureInterfaces.Services.ObjectPool.Generic;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.Presentations.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;

namespace Sources.Scripts.Infrastructure.Services.Spawners
{
    public class BulletSpawnService : IBulletSpawnService
    {
        private readonly IObjectPool<BulletView> _objectPool;
        private readonly IBulletViewFactory _bulletViewFactory;

        public BulletSpawnService(
            IObjectPool<BulletView> objectPool,
            IBulletViewFactory bulletViewFactory)
        {
            _objectPool = objectPool ?? throw new ArgumentNullException(nameof(objectPool));
            _bulletViewFactory = bulletViewFactory ?? throw new ArgumentNullException(nameof(bulletViewFactory));
        }
        
        public IBulletView Spawn(IWeaponView weaponView)
        {
            IBulletView bulletView = SpawnFromPool(weaponView) ?? _bulletViewFactory.Create(weaponView);
            
            bulletView.SetPosition(weaponView.BulletSpawnPoint.Transform.position);
            bulletView.SetRotation(weaponView.BulletSpawnPoint.Transform.rotation);
            bulletView.Show();
            
            return bulletView;
        }

        private IBulletView SpawnFromPool(IWeaponView weaponView)
        {
            BulletView bulletView = _objectPool.Get<BulletView>();

            if (bulletView == null)
                return null;
            
            return _bulletViewFactory.Create(bulletView, weaponView);
        }
    }
}