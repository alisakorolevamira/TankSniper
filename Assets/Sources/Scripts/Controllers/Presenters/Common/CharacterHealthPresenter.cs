using System;
using Sources.Scripts.Domain.Models.Common;

namespace Sources.Scripts.Controllers.Presenters.Common
{
    public class CharacterHealthPresenter : PresenterBase
    {
        private readonly CharacterHealth characterHealth;

        public CharacterHealthPresenter(CharacterHealth characterHealth)
        {
            this.characterHealth = characterHealth ?? throw new ArgumentNullException(nameof(characterHealth));
        }

        public void TakeDamage(int damage) =>
            characterHealth.TakeDamage(damage);
    }
}