using System;
using Sources.Scripts.Domain.Models.Weapons;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;
using Sources.Scripts.UIFramework.ServicesInterfaces.AudioSources;

namespace Sources.Scripts.Controllers.Presenters.Weapons
{
    public class WeaponPresenter : PresenterBase
    {
        private readonly Weapon _weapon;
        private readonly IWeaponView _weaponView;
        private readonly IBulletSpawnService _bulletSpawnService;
        private readonly IAudioService _audioService;

        public WeaponPresenter(Weapon weapon,
            IWeaponView weaponView,
            IBulletSpawnService bulletSpawnService,
            IAudioService audioService)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _weaponView = weaponView ?? throw new ArgumentNullException(nameof(weaponView));
            _bulletSpawnService = bulletSpawnService ?? throw new ArgumentNullException(nameof(bulletSpawnService));
            _audioService = audioService ?? throw new ArgumentNullException(nameof(audioService));
        }

        public override void Enable() => 
            _weapon.Attacked += OnAttack;

        public override void Disable() => 
            _weapon.Attacked -= OnAttack;

        public void DealDamage(IEnemyHealthView enemyHealthView) =>
            enemyHealthView.TakeDamage(_weapon.Damage);

        private void OnAttack()
        {
            _bulletSpawnService.Spawn(_weaponView);
            _audioService.Play();
        }
    }
}