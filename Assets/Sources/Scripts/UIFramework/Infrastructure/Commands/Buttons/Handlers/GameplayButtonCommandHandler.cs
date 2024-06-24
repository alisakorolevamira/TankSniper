using System.Collections.Generic;
using Doozy.Runtime.UIManager.Components;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.Infrastructure.Commands.Forms;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons.Handlers;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons.Handlers
{
    public class GameplayButtonCommandHandler : IButtonCommandHandler
    {
        private readonly Dictionary<ButtonCommandId, IButtonCommand> _commands =
            new Dictionary<ButtonCommandId, IButtonCommand>();
        
        public GameplayButtonCommandHandler(
            LoadMainMenuSceneCommand loadMainMenuSceneCommand,
            UnPauseButtonCommand unPauseButtonCommand,
            //ShowRewardedAdvertisingButtonCommand showRewardedAdvertisingButtonCommand,
            //ClearSavesButtonCommand clearSavesButtonCommand
            SetCameraToShootPositionCommand setCameraToShootPositionCommand,
            SetCameraToMainPositionCommand setCameraToMainPositionCommand)
        {
            _commands[loadMainMenuSceneCommand.Id] = loadMainMenuSceneCommand;
            _commands[unPauseButtonCommand.Id] = unPauseButtonCommand;
            //_commands[showRewardedAdvertisingButtonCommand.Id] = showRewardedAdvertisingButtonCommand;
            //_commands[clearSavesButtonCommand.Id] = clearSavesButtonCommand;
        }

        public void Handle(ButtonCommandId buttonCommandId)
        {
            if (_commands.ContainsKey(buttonCommandId) == false)
                throw new KeyNotFoundException(nameof(buttonCommandId));

            _commands[buttonCommandId].Handle();

        }
    }
}