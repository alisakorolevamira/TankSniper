using System;
using Sources.Scripts.Domain.Models.Weapons;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.Weapons
{
    public class WeaponPresenter : PresenterBase
    {
        private readonly Weapon _weapon;
        private readonly IWeaponView _weaponView;
        private readonly IBulletSpawnService _bulletSpawnService;

        public WeaponPresenter(Weapon weapon, IWeaponView weaponView, IBulletSpawnService bulletSpawnService)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _weaponView = weaponView ?? throw new ArgumentNullException(nameof(weaponView));
            _bulletSpawnService = bulletSpawnService ?? throw new ArgumentNullException(nameof(bulletSpawnService));
        }

        public override void Enable() => 
            _weapon.Attacked += OnAttack;

        public override void Disable() => 
            _weapon.Attacked -= OnAttack;

        public void DealDamage(IEnemyHealthView enemyHealthView) =>
            enemyHealthView.TakeDamage(_weapon.Damage);

        private void OnAttack() => 
            _bulletSpawnService.Spawn(_weaponView);
    }
}