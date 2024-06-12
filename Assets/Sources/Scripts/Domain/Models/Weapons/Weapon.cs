using System;
using Sources.Scripts.DomainInterfaces.Models.Weapons;

namespace Sources.Scripts.Domain.Models.Weapons
{
    public class Weapon : IWeapon
    {
        public event Action Attacked;

        public Weapon(float damage)
        {
            Damage = damage;
        }
        
        public float Damage { get; private set; }
        
        public void Attack( )
        {
            Attacked?.Invoke();
        }
    }
}