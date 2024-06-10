using System;
using Sources.Scripts.Controllers.Presenters.Common;
using Sources.Scripts.Domain.Models.Common;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Common;
using Sources.Scripts.Presentations.Views.Common;
using Sources.Scripts.PresentationsInterfaces.Views.Common;

namespace Sources.Scripts.Infrastructure.Factories.Views.Common
{
    public class CharacterAttackerViewFactory
    {
        private readonly CharacterAttackerPresenterFactory _presenterFactory;

        public CharacterAttackerViewFactory(CharacterAttackerPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public ICharacterAttackerView Create(CharacterAttacker characterAttacker, CharacterAttackerView view)
        {
            CharacterAttackerPresenter presenter = _presenterFactory.Create(characterAttacker);

            view.Construct(presenter);

            return view;
        }
    }
}