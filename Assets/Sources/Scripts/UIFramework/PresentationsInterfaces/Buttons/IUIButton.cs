using System.Collections.Generic;
using Sources.Scripts.PresentationsInterfaces.UI.Buttons;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.Presentations.Buttons.Types;
using Sources.Scripts.UIFramework.Presentations.Views.Types;

namespace Sources.Scripts.UIFramework.PresentationsInterfaces.Buttons
{
    public interface IUIButton : IButtonView
    {
        float Delay { get; }
        List<ButtonCommandId> OnClickCommandId { get; }
        List<ButtonCommandId> EnableCommandId { get; }
        List<ButtonCommandId> DisableCommandId { get; }
        UseButtonType UseButtonType { get; }
        FormId FormId { get; }
    }
}