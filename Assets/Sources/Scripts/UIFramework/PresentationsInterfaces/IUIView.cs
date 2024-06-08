using System.Collections.Generic;
using Sources.Scripts.PresentationsInterfaces.Views;
using Sources.Scripts.UIFramework.Presentations.CommonTypes;
using Sources.Scripts.UIFramework.Presentations.Views.Types;

namespace Sources.Scripts.UIFramework.PresentationsInterfaces
{
    public interface IUIView : IView
    {
        public Enable EnabledGameObject { get; }
        public Enable EnabledCanvasGroup { get; }
        public IReadOnlyList<FormId> OnEnableEnabledForms { get; }
        public IReadOnlyList<FormId> OnEnableDisabledForms { get; }
        
        FormId FormId { get; }
        bool IsActive { get; }
    }
}