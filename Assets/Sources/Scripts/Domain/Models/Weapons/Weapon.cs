using System;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.DomainInterfaces.Models.Weapons;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Weapons
{
    public class Weapon : IWeapon
    {
        public event Action Attacked;

        public Weapon(float damage)
        {
            Damage = damage;
        }
        
        public float Damage { get; }
        
        public void Attack() => 
            Attacked?.Invoke();
    }
}