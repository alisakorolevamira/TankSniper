using System;
using Sources.Scripts.Controllers.Presenters.Players;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Common;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Players;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Players;

namespace Sources.Scripts.Infrastructure.Factories.Views.Players
{
    public class PlayerAttackerViewFactory
    {
        private readonly PlayerAttackerPresenterFactory _presenterFactory;

        public PlayerAttackerViewFactory(PlayerAttackerPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IPlayerAttackerView Create(PlayerAttacker playerAttacker, PlayerAttackerView view)
        {
            PlayerAttackerPresenter presenter = _presenterFactory.Create(playerAttacker, view);

            view.Construct(presenter);

            return view;
        }
    }
}