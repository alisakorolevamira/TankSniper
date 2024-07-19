using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Weapons;
using Sources.Scripts.Infrastructure.Services.InputServices;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Bullets;
using Sources.Scripts.InfrastructureInterfaces.Services.ObjectPool.Generic;
using Sources.Scripts.Presentations.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.ObjectPool;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Scripts.Infrastructure.Factories.Views.Bullets
{
    public class BulletViewFactory : IBulletViewFactory
    {
        private readonly IObjectPool<BulletView> _objectPool;
        private readonly GameplayInputService _inputService;

        public BulletViewFactory(IObjectPool<BulletView> objectPool, GameplayInputService inputService)
        {
            _objectPool = objectPool ?? throw new ArgumentNullException(nameof(objectPool));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
        }

        public IBulletView Create(IWeaponView weaponView)
        {
            if (weaponView.WeaponType == WeaponType.Dron)
            {
                DronBulletView view = CreateDronView();
                return CreateDronBullet(view, weaponView);
            }

            BulletView bulletView = CreateTankView();
            return CreateTankBullet(bulletView, weaponView);
        }

        public IBulletView CreateTankBullet(BulletView bulletView, IWeaponView weaponView)
        {
            bulletView.Construct(weaponView);
            bulletView.SetParent(null);
            
            return bulletView;
        }
        
        public IBulletView CreateDronBullet(DronBulletView bulletView, IWeaponView weaponView)
        {
            bulletView.Construct(weaponView);
            bulletView.SetParent(null);
            bulletView.SetInput(_inputService);
            
            return bulletView;
        }

        private BulletView CreateTankView()
        {
            BulletView bulletView = Object.Instantiate(
                Resources.Load<BulletView>(PrefabPath.TankBullet));

            bulletView
                .AddComponent<PoolableObject>()
                .SetPool(_objectPool);

            return bulletView;
        }
        
        private DronBulletView CreateDronView()
        {
            DronBulletView bulletView = Object.Instantiate(
                Resources.Load<DronBulletView>(PrefabPath.DronBullet));

            bulletView
                .AddComponent<PoolableObject>()
                .SetPool(_objectPool);

            return bulletView;
        }
    }
}