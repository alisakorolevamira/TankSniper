using System.Collections.Generic;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons.Handlers;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Buttons;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons.Handlers
{
    public class MainMenuButtonCommandHandler : IButtonCommandHandler
    {
        private readonly Dictionary<ButtonCommandId, IButtonCommand> _commands = new ();
        
        public MainMenuButtonCommandHandler(
            ShowFormCommand showFormCommand,
            HideFormCommand hideFormCommand,
            AddTankCommand addTankCommand,
            CompleteTutorialCommand completeTutorialCommand,
            LoadGameCommand loadGameCommand)
        {
            _commands[showFormCommand.Id] = showFormCommand;
            _commands[loadGameCommand.Id] = loadGameCommand;
            _commands[hideFormCommand.Id] = hideFormCommand;
            _commands[completeTutorialCommand.Id] = completeTutorialCommand;
            _commands[addTankCommand.Id] = hideFormCommand;
        }
        
        public void Handle(IUIButton uiButton, ButtonCommandId buttonCommandId)
        {
            if (_commands.ContainsKey(buttonCommandId) == false)
                throw new KeyNotFoundException(nameof(buttonCommandId));

            _commands[buttonCommandId].Handle(uiButton);
        }
    }
}