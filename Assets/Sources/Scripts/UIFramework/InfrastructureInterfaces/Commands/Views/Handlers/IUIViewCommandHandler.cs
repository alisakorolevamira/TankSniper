using Sources.Scripts.UIFramework.Domain.Commands;

namespace Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Views.Handlers
{
    public interface IUIViewCommandHandler
    {
        void Handle(FormCommandId formCommandId);
    }
}