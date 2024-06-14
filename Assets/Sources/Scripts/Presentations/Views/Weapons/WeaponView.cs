using Sources.Scripts.Controllers.Presenters.Weapons;
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
        
        public IBulletSpawnPoint BulletSpawnPoint => _bulletSpawnPoint;
        
        public void DealDamage(IEnemyHealthView enemyHealthView) =>
            Presenter.DealDamage(enemyHealthView);
    }
}