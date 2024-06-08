using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Buttons;

namespace Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons
{
    public interface IButtonCommand
    {
        ButtonCommandId Id { get; }

        void Handle(IUIButton uiButton);
    }
}