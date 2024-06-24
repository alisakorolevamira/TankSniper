using System;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Weapons
{
    public interface IReloadWeaponService
    {
        event Action StartTimer;
        void ReloadWeapon();
    }
}