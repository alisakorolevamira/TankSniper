using System.Collections.Generic;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons.Handlers;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Buttons;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons.Handlers
{
    public class GameplayButtonCommandHandler : IButtonCommandHandler
    {
        private readonly Dictionary<ButtonCommandId, IButtonCommand> _commands =
            new Dictionary<ButtonCommandId, IButtonCommand>();
        
        public GameplayButtonCommandHandler(
            ShowFormCommand showFormCommand,
            LoadMainMenuSceneCommand loadMainMenuSceneCommand,
            UnPauseButtonCommand unPauseButtonCommand,
            HideFormCommand hideFormCommand,
            //ShowRewardedAdvertisingButtonCommand showRewardedAdvertisingButtonCommand,
            //ClearSavesButtonCommand clearSavesButtonCommand
            SetCameraToShootPositionCommand setCameraToShootPositionCommand,
            SetCameraToMainPositionCommand setCameraToMainPositionCommand)
        {
            _commands[showFormCommand.Id] = showFormCommand;
            _commands[loadMainMenuSceneCommand.Id] = loadMainMenuSceneCommand;
            _commands[unPauseButtonCommand.Id] = unPauseButtonCommand;
            _commands[hideFormCommand.Id] = hideFormCommand;
            //_commands[showRewardedAdvertisingButtonCommand.Id] = showRewardedAdvertisingButtonCommand;
            //_commands[clearSavesButtonCommand.Id] = clearSavesButtonCommand;
            _commands[setCameraToShootPositionCommand.Id] = setCameraToShootPositionCommand;
            _commands[setCameraToMainPositionCommand.Id] = setCameraToMainPositionCommand;
        }

        public void Handle(IUIButton uiButton, ButtonCommandId buttonCommandId)
        {
            if (_commands.ContainsKey(buttonCommandId) == false)
                throw new KeyNotFoundException(nameof(buttonCommandId));

            _commands[buttonCommandId].Handle(uiButton);

        }
    }
}