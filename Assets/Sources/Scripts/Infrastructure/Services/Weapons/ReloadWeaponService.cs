using System;
using Sources.Scripts.InfrastructureInterfaces.Services.Weapons;

namespace Sources.Scripts.Infrastructure.Services.Weapons
{
    public class ReloadWeaponService : IReloadWeaponService
    {
        public event Action StartTimer;
        
        public void ReloadWeapon() => 
            StartTimer?.Invoke();
    }
}