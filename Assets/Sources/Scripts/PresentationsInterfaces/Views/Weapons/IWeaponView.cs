using Sources.Scripts.Domain.Models.Weapons;
using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies;

namespace Sources.Scripts.PresentationsInterfaces.Views.Weapons
{
    public interface IWeaponView
    {
        WeaponType WeaponType { get; }
        IBulletSpawnPoint BulletSpawnPoint { get; }
        
        void DealDamage(IEnemyHealthView enemyHealthView);
    }
}