using System.Collections.Generic;
using Sources.Scripts.Presentations.Views;
using Sources.Scripts.UIFramework.Presentations.Views;
using Sources.Scripts.UIFramework.Presentations.Views.Types;
using Sources.Scripts.UIFramework.PresentationsInterfaces;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;

namespace Sources.Scripts.UIFramework.Services.Forms
{
    public class FormService : IFormService
    {
        private readonly ContainerView _containerView;
        private readonly Dictionary<FormId, IUIView> _forms = new Dictionary<FormId, IUIView>();

        public FormService(UICollector uiCollector)
        {
            foreach (IUIView form in uiCollector.UIContainers)
                _forms.Add(form.FormId, form);
        }

        public void Show(FormId formId)
        {
            if (_forms.ContainsKey(formId) == false)
                throw new KeyNotFoundException(nameof(formId));

            _forms[formId].Show();
        }

        public void Hide(FormId formId)
        {
            if (_forms.ContainsKey(formId) == false)
                throw new KeyNotFoundException(nameof(formId));

            if(_forms[formId] == null)
                return;
            
            _forms[formId].Hide();
        }

        public bool IsActive(FormId formId)
        {
            if (_forms.ContainsKey(formId) == false)
                throw new KeyNotFoundException(nameof(formId));

            return _forms[formId].IsActive;
        }
    }
}