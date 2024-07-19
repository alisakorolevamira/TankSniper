using System;
using Sources.Scripts.Domain.Models.Weapons;
using Sources.Scripts.Infrastructure.Services.InputServices;
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
            bulletView.Move(weaponView.BulletSpawnPoint.Transform.forward);
            
            return bulletView;
        }

        private IBulletView SpawnFromPool(IWeaponView weaponView)
        {
            if (weaponView.WeaponType == WeaponType.Tank)
            {
                BulletView view = _objectPool.Get<BulletView>();

                return view == null ? null : _bulletViewFactory.CreateTankBullet(view, weaponView);
            }

            DronBulletView bulletView = _objectPool.Get<DronBulletView>();

            return bulletView == null ? null : _bulletViewFactory.CreateDronBullet(bulletView, weaponView);
        }
    }
}