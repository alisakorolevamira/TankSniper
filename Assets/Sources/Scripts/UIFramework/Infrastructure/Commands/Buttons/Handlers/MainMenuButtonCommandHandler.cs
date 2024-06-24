using System.Collections.Generic;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons.Handlers;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons.Handlers
{
    public class MainMenuButtonCommandHandler : IButtonCommandHandler
    {
        private readonly Dictionary<ButtonCommandId, IButtonCommand> _commands = new ();
        
        public MainMenuButtonCommandHandler(
            AddTankCommand addTankCommand,
            CompleteTutorialCommand completeTutorialCommand,
            LoadGameCommand loadGameCommand)
        {
            _commands[loadGameCommand.Id] = loadGameCommand;
            _commands[completeTutorialCommand.Id] = completeTutorialCommand;
            _commands[addTankCommand.Id] = addTankCommand;
        }
        
        public void Handle(ButtonCommandId buttonCommandId)
        {
            if (_commands.ContainsKey(buttonCommandId) == false)
                throw new KeyNotFoundException(nameof(buttonCommandId));

            _commands[buttonCommandId].Handle();
        }
    }
}