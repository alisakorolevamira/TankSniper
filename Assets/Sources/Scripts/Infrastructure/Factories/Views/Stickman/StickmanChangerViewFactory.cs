using System;
using Sources.Scripts.Controllers.Presenters.Stickman;
using Sources.Scripts.Domain.Models.Stickman;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Stickman;
using Sources.Scripts.Presentations.Views.Stickman;
using Sources.Scripts.PresentationsInterfaces.Views.Stickman;

namespace Sources.Scripts.Infrastructure.Factories.Views.Stickman
{
    public class StickmanChangerViewFactory
    {
        private readonly StickmanChangerPresenterFactory _presenterFactory;

        public StickmanChangerViewFactory(StickmanChangerPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IStickmanChangerView Create(StickmanChanger stickmanChanger, StickmanChangerView view)
        {
            StickmanChangerPresenter presenter = _presenterFactory.Create(stickmanChanger, view);
            
            view.Construct(presenter);

            return view;
        }
    }
}