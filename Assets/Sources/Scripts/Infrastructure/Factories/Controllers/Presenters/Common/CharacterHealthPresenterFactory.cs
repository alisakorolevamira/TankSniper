using Sources.Scripts.Controllers.Presenters.Common;
using Sources.Scripts.Domain.Models.Common;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Common
{
    public class CharacterHealthPresenterFactory
    {
        public CharacterHealthPresenter Create(CharacterHealth characterHealth) => 
            new(characterHealth);
    }
}