using Doozy.Runtime.UIManager.Components;
using Sources.Scripts.UIFramework.Domain.Commands;

namespace Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons
{
    public interface IButtonCommand
    {
        ButtonCommandId Id { get; }

        void Handle();
    }
}