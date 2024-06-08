using Sources.Scripts.UIFramework.Presentations.Views.Types;

namespace Sources.Scripts.UIFramework.ServicesInterfaces.Forms
{
    public interface IFormService
    {
        void Show(FormId formId);
        void Hide(FormId formId);
        bool IsActive(FormId formId);
    }
}