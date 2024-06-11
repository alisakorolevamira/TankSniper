using System;
using Sources.Scripts.InfrastructureInterfaces.Services.Cameras;
using Sources.Scripts.Presentations.Views.Cameras.Types;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Views;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Buttons;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons.Handlers
{
    public class SetCameraToMainPositionCommand : IViewCommand
    {
        private readonly ICameraService _cameraService;

        public SetCameraToMainPositionCommand(ICameraService cameraService)
        {
            _cameraService = cameraService ?? throw new ArgumentNullException(nameof(cameraService));
        }

        public FormCommandId Id => FormCommandId.SetCameraToMainPosition;
        
        public void Handle() => 
            _cameraService.SetPosition(PositionId.MainPosition);
    }
}