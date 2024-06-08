using System;
using Sources.Scripts.InfrastructureInterfaces.Services.PauseServices;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Views;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Forms
{
    public class UnPauseCommand : IViewCommand
    {
        private readonly IPauseService _pauseService;

        public UnPauseCommand(IPauseService pauseService)
        {
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
        }

        public FormCommandId Id => FormCommandId.UnPause;
        
        public void Handle() =>
            _pauseService.Continue();
    }
}