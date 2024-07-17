using Sources.Scripts.Controllers.Presenters.Weapons;
using Sources.Scripts.Domain.Models.Weapons;
using Sources.Scripts.Presentations.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Weapons
{
    public class WeaponView : PresentableView<WeaponPresenter>, IWeaponView
    {
        [SerializeField] private BulletSpawnPoint _bulletSpawnPoint;
        [SerializeField] private WeaponType _weaponType;
        
        public IBulletSpawnPoint BulletSpawnPoint => _bulletSpawnPoint;
        public WeaponType WeaponType => _weaponType;
        
        public void DealDamage(IEnemyHealthView enemyHealthView) =>
            Presenter.DealDamage(enemyHealthView);
    }
}