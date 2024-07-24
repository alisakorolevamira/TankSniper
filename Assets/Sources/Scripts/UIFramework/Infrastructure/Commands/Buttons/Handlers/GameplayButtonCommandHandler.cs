using System.Collections.Generic;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons.Handlers;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons.Handlers
{
    public class GameplayButtonCommandHandler : IButtonCommandHandler
    {
        private readonly Dictionary<ButtonCommandId, IButtonCommand> _commands = new();
        
        public GameplayButtonCommandHandler(
            LoadMainMenuSceneCommand loadMainMenuSceneCommand,
            LoadGameCommand loadGameCommand,
            UnpauseCommand unpauseCommand,
            ChangeVolumeCommand changeVolumeCommand,
            ShowInterstitialAdCommand showInterstitialAdCommand)

        {
            _commands[loadMainMenuSceneCommand.Id] = loadMainMenuSceneCommand;
            _commands[loadGameCommand.Id] = loadGameCommand;
            _commands[unpauseCommand.Id] = unpauseCommand;
            _commands[changeVolumeCommand.Id] = changeVolumeCommand;
            _commands[showInterstitialAdCommand.Id] = showInterstitialAdCommand;
        }

        public void Handle(ButtonCommandId buttonCommandId)
        {
            if (_commands.ContainsKey(buttonCommandId) == false)
                throw new KeyNotFoundException(nameof(buttonCommandId));

            _commands[buttonCommandId].Handle();

        }
    }
}