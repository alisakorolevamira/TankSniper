using System.Collections.Generic;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons.Handlers;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Views;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Views.Handlers;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Forms.Handlers
{
    public class GameplayUIViewCommandHandler : IUIViewCommandHandler
    {
        private readonly Dictionary<FormCommandId, IViewCommand> _commands = new ();
        
        public GameplayUIViewCommandHandler(
            PauseCommand pauseCommand,
            SetCameraToShootPositionCommand setCameraToShootPositionCommand,
            SetCameraToMainPositionCommand setCameraToMainPositionCommand,
            ReloadWeaponCommand reloadWeaponCommand,
            OpenNewStickmanCommand openNewStickmanCommand)
        {
            _commands[pauseCommand.Id] = pauseCommand;
            _commands[setCameraToShootPositionCommand.Id] = setCameraToShootPositionCommand;
            _commands[setCameraToMainPositionCommand.Id] = setCameraToMainPositionCommand;
            _commands[reloadWeaponCommand.Id] = reloadWeaponCommand;
            _commands[openNewStickmanCommand.Id] = openNewStickmanCommand;
        }

        public void Handle(FormCommandId formCommandId)
        {
            if(_commands.ContainsKey(formCommandId) == false)
                throw new KeyNotFoundException(nameof(formCommandId));
            
            _commands[formCommandId].Handle();
        }
    }
}