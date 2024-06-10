using System;
using Sources.Scripts.Domain.Models.Common;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Players;

namespace Sources.Scripts.Controllers.Presenters.Players
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