using System;
using Sources.Scripts.Controllers.Presenters;
using Sources.Scripts.UIFramework.Presentations.Views;
using Sources.Scripts.UIFramework.Presentations.Views.Types;
using Sources.Scripts.UIFramework.Services.Views;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;
using Sources.Scripts.UIFramework.ServicesInterfaces.Views;

namespace Sources.Scripts.UIFramework.Controllers.Forms
{
    public class UIViewPresenter : PresenterBase
    {
        private readonly UIView _uiView;
        private readonly IUIViewService _uiViewService;
        private readonly IFormService _formService;
        
        public UIViewPresenter(
            UIView uiView,
            IUIViewService uiViewService,
            IFormService formService)
        {
            _uiView = uiView ? uiView : throw new ArgumentNullException(nameof(uiView));
            _uiViewService = uiViewService ?? throw new ArgumentNullException(nameof(uiViewService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }
        
        public override void Enable()
        {
            _uiViewService.Handle(_uiView.EnabledFormCommands);

            foreach (FormId formId in _uiView.OnEnableEnabledForms)
                _formService.Show(formId);
            foreach (FormId formId in _uiView.OnEnableDisabledForms)
                _formService.Hide(formId);
        }

        public override void Disable()
        {
            _uiViewService.Handle(_uiView.DisabledFormCommands);
            
            foreach (FormId formId in _uiView.OnDisableEnabledForms)
                _formService.Show(formId);
            foreach (FormId formId in _uiView.OnDisableDisabledForms)
                _formService.Hide(formId);
        }
    }
}