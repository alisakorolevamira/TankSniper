using System;
using Sources.Scripts.UIFramework.Controllers.Buttons;
using Sources.Scripts.UIFramework.Presentations.Buttons;
using Sources.Scripts.UIFramework.ServicesInterfaces.Buttons;

namespace Sources.Scripts.UIFramework.Infrastructure.Factories.Controllers.Buttons
{
    public class UIButtonPresenterFactory
    {
        private readonly IUIButtonService _uiButtonService;

        public UIButtonPresenterFactory(IUIButtonService uiButtonService)
        {
            _uiButtonService = uiButtonService ?? 
                               throw new ArgumentNullException(nameof(uiButtonService));
        }

        public UIButtonPresenter Create(UIButton view) =>
            new(view, _uiButtonService);
    }
}