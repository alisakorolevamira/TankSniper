using Sources.Scripts.UIFramework.Domain.Commands;

namespace Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons.Handlers
{
    public interface IButtonCommandHandler
    {
        void Handle(ButtonCommandId buttonCommandId);
    }
}