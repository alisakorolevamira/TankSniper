using System;
using Sources.Scripts.Controllers.Presenters.Players;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Players;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Players;

namespace Sources.Scripts.Infrastructure.Factories.Views.Players
{
    public class AttackerUIViewFactory
    {
        private readonly AttackerUIPresenterFactory _presenterFactory;

        public AttackerUIViewFactory(AttackerUIPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IAttackerUIView Create(AttackerUIView view)
        {
            AttackerUIPresenter presenter = _presenterFactory.Create(view);

            view.Construct(presenter);

            return view;
        }
    }
}