using System;
using Sources.Scripts.Domain.Models.Constants;
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

        public BulletViewFactory(IObjectPool<BulletView> objectPool)
        {
            _objectPool = objectPool ?? throw new ArgumentNullException(nameof(objectPool));
        }

        public IBulletView Create(IWeaponView weaponView)
        {
            BulletView bulletView = CreateView();

            return Create(bulletView, weaponView);
        }

        public IBulletView Create(BulletView bulletView, IWeaponView weaponView)
        {
            bulletView.Construct(weaponView);
            bulletView.SetParent(null);
            
            return bulletView;
        }

        private BulletView CreateView()
        {
            BulletView bulletView = Object.Instantiate(
                Resources.Load<BulletView>(PrefabPath.Bullet));

            bulletView
                .AddComponent<PoolableObject>()
                .SetPool(_objectPool);

            return bulletView;
        }
    }
}