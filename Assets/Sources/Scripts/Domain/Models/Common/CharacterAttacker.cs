using System;
using System.Threading;
using Sources.Scripts.DomainInterfaces.Models.Weapons;

namespace Sources.Scripts.Domain.Models.Common
{
    public class CharacterAttacker
    {
        private readonly IWeapon _weapon;

        public CharacterAttacker(IWeapon weapon)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public void Attack(CancellationToken cancellationToken) =>
            _weapon.AttackAsync(cancellationToken);

        public void EndAttack() =>
            _weapon.EndAttack();
    }
}