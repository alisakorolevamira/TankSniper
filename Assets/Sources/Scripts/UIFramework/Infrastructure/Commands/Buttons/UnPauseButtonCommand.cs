using System;
using Doozy.Runtime.UIManager.Components;
using Sources.Scripts.InfrastructureInterfaces.Services.PauseServices;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons
{
    public class UnPauseButtonCommand : IButtonCommand
    {
        private readonly IPauseService _pauseService;

        public UnPauseButtonCommand(IPauseService pauseService)
        {
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
        }

        public ButtonCommandId Id => ButtonCommandId.UnPause;
        
        public void Handle() =>
            _pauseService.Continue();
    }
}