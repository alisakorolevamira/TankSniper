using System;
using Sources.Scripts.UIFramework.Controllers.Buttons;
using Sources.Scripts.UIFramework.Infrastructure.Factories.Controllers.Buttons;
using Sources.Scripts.UIFramework.Presentations.Buttons;

namespace Sources.Scripts.UIFramework.Infrastructure.Factories.Views.Buttons
{
    public class UIButtonFactory
    {
        private readonly UIButtonPresenterFactory _presenterFactory;

        public UIButtonFactory(UIButtonPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? 
                                throw new ArgumentNullException(nameof(presenterFactory));
        }

        public UIButton Create(UIButton view)
        {
            UIButtonPresenter presenter = _presenterFactory.Create(view);
            
            view.Construct(presenter);

            return view;
        }
    }
}