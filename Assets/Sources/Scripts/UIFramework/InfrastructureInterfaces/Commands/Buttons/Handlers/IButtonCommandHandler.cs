using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Buttons;

namespace Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons.Handlers
{
    public interface IButtonCommandHandler
    {
        void Handle(IUIButton uiButton, ButtonCommandId buttonCommandId);
    }
}