using System;
using System.Threading;
using Sources.Scripts.DomainInterfaces.Models.Weapons;

namespace Sources.Scripts.Domain.Models.Players
{
    public class PlayerAttacker
    {
        private readonly IWeapon _weapon;

        public PlayerAttacker(IWeapon weapon)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public void Attack() =>
            _weapon.Attack();
    }
}