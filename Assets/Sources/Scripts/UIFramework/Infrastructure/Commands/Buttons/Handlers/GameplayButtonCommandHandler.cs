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
            LoadGameCommand loadGameCommand,
            ChangeVolumeCommand changeVolumeCommand)
            //ShowRewardedAdvertisingButtonCommand showRewardedAdvertisingButtonCommand,

        {
            _commands[loadMainMenuSceneCommand.Id] = loadMainMenuSceneCommand;
            _commands[loadGameCommand.Id] = loadGameCommand;
            _commands[changeVolumeCommand.Id] = changeVolumeCommand;
            //_commands[showRewardedAdvertisingButtonCommand.Id] = showRewardedAdvertisingButtonCommand;
        }

        public void Handle(ButtonCommandId buttonCommandId)
        {
            if (_commands.ContainsKey(buttonCommandId) == false)
                throw new KeyNotFoundException(nameof(buttonCommandId));

            _commands[buttonCommandId].Handle();

        }
    }
}