using System.Collections.Generic;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Buttons;

namespace Sources.Scripts.UIFramework.ServicesInterfaces.Buttons
{
    public interface IUIButtonService
    {
        void Handle(IEnumerable<ButtonCommandId> commandIds, IUIButton uiButton);
    }
}