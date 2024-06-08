using System.Collections.Generic;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Views.Handlers;
using Sources.Scripts.UIFramework.ServicesInterfaces.Views;

namespace Sources.Scripts.UIFramework.Services.Views
{
    public class UIViewService : IUIViewService
    {
        private readonly IUIViewCommandHandler _uiViewCommandHandler;

        public UIViewService(IUIViewCommandHandler uiViewCommandHandler)
        {
            _uiViewCommandHandler = uiViewCommandHandler;
        }

        public void Handle(IEnumerable<FormCommandId> commandIds)
        {
            foreach (FormCommandId commandId in commandIds)
                _uiViewCommandHandler.Handle(commandId);
        }
    }
}