using System.Collections.Generic;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons.Handlers;

namespace Sources.Scripts.UIFramework.Infrastructure.Buttons
{
    public class ButtonCommandHandler : IButtonCommandHandler
    {
        private readonly Dictionary<ButtonCommandId, IButtonCommand> _commands = new ();

        public ButtonCommandHandler(
            CompleteTutorialCommand completeTutorialCommand,
            LoadMainMenuSceneCommand loadMainMenuSceneCommand,
            UnPauseButtonCommand unPauseButtonCommand)
        {
            _commands[completeTutorialCommand.Id] = completeTutorialCommand;
            _commands[loadMainMenuSceneCommand.Id] = loadMainMenuSceneCommand;
            _commands[unPauseButtonCommand.Id] = unPauseButtonCommand;
        }

        public void Handle(ButtonCommandId buttonCommandId)
        {
            if (_commands.ContainsKey(buttonCommandId) == false)
                throw new KeyNotFoundException(nameof(buttonCommandId));

            _commands[buttonCommandId].Handle();
        }
    }
}