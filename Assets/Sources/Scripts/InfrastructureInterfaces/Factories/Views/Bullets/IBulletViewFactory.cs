using Sources.Scripts.Presentations.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;

namespace Sources.Scripts.InfrastructureInterfaces.Factories.Views.Bullets
{
    public interface IBulletViewFactory
    {
        IBulletView Create(IWeaponView weaponView);
        IBulletView CreateTankBullet(BulletView bulletView, IWeaponView weaponView);
        IBulletView CreateDronBullet(DronBulletView bulletView, IWeaponView weaponView);
    }
}