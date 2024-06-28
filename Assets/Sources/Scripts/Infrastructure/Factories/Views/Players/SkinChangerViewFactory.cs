using System;
using Sources.Scripts.Controllers.Presenters.Players;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Players;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.Presentations.Views.Players.Skins;
using Sources.Scripts.PresentationsInterfaces.Views.Players;

namespace Sources.Scripts.Infrastructure.Factories.Views.Players
{
    public class SkinChangerViewFactory
    {
        private readonly SkinChangerPresenterFactory _presenterFactory;

        public SkinChangerViewFactory(SkinChangerPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public ISkinChangerView Create(SkinChanger skinChanger, SkinChangerView view)
        {
            SkinChangerPresenter presenter = _presenterFactory.Create(skinChanger, view);
            
            view.Construct(presenter);

            return view;
        }
    }
}