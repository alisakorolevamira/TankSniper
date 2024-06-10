using Sources.Scripts.Controllers.Presenters.Players;
using Sources.Scripts.Domain.Models.Common;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Common
{
    public class CharacterHealthPresenterFactory
    {
        public CharacterHealthPresenter Create(CharacterHealth characterHealth)
        {
            return new CharacterHealthPresenter(characterHealth);
        }
    }
}