using System;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.DomainInterfaces.Models.Weapons;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Weapons
{
    public class Weapon : IWeapon
    {
        private readonly Upgrader _upgrader;
        public event Action Attacked;

        public Weapon(float damage)
        {
            //_upgrader = upgrader;
            Damage = damage;
        }
        
        public float Damage { get; private set; }
        
        public void Attack( ) => 
            Attacked?.Invoke();
    }
}