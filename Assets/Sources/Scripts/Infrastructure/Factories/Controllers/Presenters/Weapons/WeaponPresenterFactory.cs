using System;
using Sources.Scripts.Controllers.Presenters.Weapons;
using Sources.Scripts.Domain.Models.Weapons;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;
using Sources.Scripts.UIFramework.ServicesInterfaces.AudioSources;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Weapons
{
    public class WeaponPresenterFactory
    {
        private readonly IBulletSpawnService _bulletSpawnService;
        private readonly IAudioService _audioService;
        
        public WeaponPresenterFactory(IBulletSpawnService bulletSpawnService, IAudioService audioService)
        {
            _bulletSpawnService = bulletSpawnService ?? throw new ArgumentNullException(nameof(bulletSpawnService));
            _audioService = audioService ?? throw new ArgumentNullException(nameof(audioService));
        }

        public WeaponPresenter Create(Weapon weapon, IWeaponView weaponView) => 
            new(weapon, weaponView, _bulletSpawnService, _audioService);
    }
}