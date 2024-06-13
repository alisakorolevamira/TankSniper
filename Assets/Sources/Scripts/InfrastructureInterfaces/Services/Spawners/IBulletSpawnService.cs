using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners
{
    public interface IBulletSpawnService
    {
        IBulletView Spawn(IWeaponView weaponView);
    }
}