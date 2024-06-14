using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies;

namespace Sources.Scripts.PresentationsInterfaces.Views.Weapons
{
    public interface IWeaponView
    {
        IBulletSpawnPoint BulletSpawnPoint { get; }
        
        void DealDamage(IEnemyHealthView enemyHealthView);
    }
}