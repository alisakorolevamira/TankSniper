using System;
using Sources.Scripts.Domain.Models.Common;

namespace Sources.Scripts.Controllers.Presenters.Common
{
    public class CharacterHealthPresenter : PresenterBase
    {
        private readonly CharacterHealth _characterHealth;

        public CharacterHealthPresenter(CharacterHealth characterHealth)
        {
            _characterHealth = characterHealth ?? throw new ArgumentNullException(nameof(characterHealth));
        }

        public void TakeDamage(int damage) =>
            _characterHealth.TakeDamage(damage);
    }
}