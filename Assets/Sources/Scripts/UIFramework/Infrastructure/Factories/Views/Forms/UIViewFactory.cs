using System;
using Sources.Scripts.UIFramework.Controllers.Forms;
using Sources.Scripts.UIFramework.Infrastructure.Factories.Controllers.Views;
using Sources.Scripts.UIFramework.Presentations.Views;

namespace Sources.Scripts.UIFramework.Infrastructure.Factories.Views.Forms
{
    public class UIViewFactory
    {
        private readonly UIViewPresenterFactory _presenterFactory;

        public UIViewFactory(UIViewPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? 
                                throw new ArgumentNullException(nameof(presenterFactory));
        }

        public UIView Create(UIView view)
        {
            UIViewPresenter presenter = _presenterFactory.Create(view);
            
            view.Construct(presenter);   
            
            return view;
        }
    }
}