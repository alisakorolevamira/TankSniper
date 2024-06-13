using System;
using Sources.Scripts.Controllers.Presenters.Weapons;
using Sources.Scripts.Domain.Models.Weapons;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Weapons
{
    public class WeaponPresenterFactory
    {
        private readonly IBulletSpawnService _bulletSpawnService;
        
        public WeaponPresenterFactory(IBulletSpawnService bulletSpawnService)
        {
            _bulletSpawnService = bulletSpawnService ?? throw new ArgumentNullException(nameof(bulletSpawnService));
        }

        public WeaponPresenter Create(Weapon weapon, IWeaponView weaponView)
        {
            return new WeaponPresenter(weapon, weaponView, _bulletSpawnService);
        }
    }
}