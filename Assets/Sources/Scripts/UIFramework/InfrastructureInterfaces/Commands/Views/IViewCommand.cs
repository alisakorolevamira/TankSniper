using Sources.Scripts.UIFramework.Domain.Commands;

namespace Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Views
{
    public interface IViewCommand
    {
        FormCommandId Id { get; }

        void Handle();
    }
}