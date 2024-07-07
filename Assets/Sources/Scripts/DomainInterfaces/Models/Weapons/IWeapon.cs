using System;

namespace Sources.Scripts.DomainInterfaces.Models.Weapons
{
    public interface IWeapon
    {
        event Action Attacked;

        float Damage { get; }

        void Attack();
    }
}