using System;
using Sources.Scripts.Controllers.Presenters.Players;
using Sources.Scripts.Domain.Models.Common;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Common;
using Sources.Scripts.Presentations.Views.Common;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Common;

namespace Sources.Scripts.Infrastructure.Factories.Views.Common
{
    public class CharacterHealthViewFactory
    {
        private readonly CharacterHealthPresenterFactory characterHealthPresenterFactory;

        public CharacterHealthViewFactory(CharacterHealthPresenterFactory characterHealthPresenterFactory)
        {
            this.characterHealthPresenterFactory = characterHealthPresenterFactory ??
                                                   throw new ArgumentNullException(nameof(characterHealthPresenterFactory));
        }

        public ICharacterHealthView Create(CharacterHealth characterHealth, CharacterHealthView characterHealthView)
        {
            CharacterHealthPresenter characterHealthPresenter =
                characterHealthPresenterFactory.Create(characterHealth);

            characterHealthView.Construct(characterHealthPresenter);

            return characterHealthView;
        }
    }
}