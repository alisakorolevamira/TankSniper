using System.Collections.Generic;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons.Handlers;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Buttons;
using Sources.Scripts.UIFramework.ServicesInterfaces.Buttons;

namespace Sources.Scripts.UIFramework.Services.Buttons
{
    public class UIButtonService : IUIButtonService
    {
        private readonly IButtonCommandHandler _commandHandler;

        public UIButtonService(IButtonCommandHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public void Handle(IEnumerable<ButtonCommandId> commandIds, IUIButton uiButton)
        {
            foreach (ButtonCommandId commandId in commandIds)
                _commandHandler.Handle(uiButton, commandId);
        }
    }
}