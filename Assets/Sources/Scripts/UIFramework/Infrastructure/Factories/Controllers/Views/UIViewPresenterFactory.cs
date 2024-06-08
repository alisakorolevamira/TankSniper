using System;
using Sources.Scripts.UIFramework.Controllers.Forms;
using Sources.Scripts.UIFramework.Presentations.Views;
using Sources.Scripts.UIFramework.Services.Views;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;

namespace Sources.Scripts.UIFramework.Infrastructure.Factories.Controllers.Views
{
    public class UIViewPresenterFactory
    {
        private readonly IUIViewService _uiViewService;
        private readonly IFormService _formService;

        public UIViewPresenterFactory(
            IUIViewService uiViewService, 
            IFormService formService)
        {
            _uiViewService = uiViewService ?? throw new ArgumentNullException(nameof(uiViewService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public UIViewPresenter Create(UIView view) =>
            new(view, _uiViewService, _formService);
    }
}