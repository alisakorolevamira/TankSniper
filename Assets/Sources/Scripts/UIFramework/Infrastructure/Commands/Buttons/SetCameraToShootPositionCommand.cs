using System;
using Sources.Scripts.InfrastructureInterfaces.Services.Cameras;
using Sources.Scripts.Presentations.Views.Cameras.Types;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Buttons;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons
{
    public class SetCameraToShootPositionCommand : IButtonCommand
    {
        private readonly ICameraService _cameraService;

        public SetCameraToShootPositionCommand(ICameraService cameraService)
        {
            _cameraService = cameraService ?? throw new ArgumentNullException(nameof(cameraService));
        }

        public ButtonCommandId Id => ButtonCommandId.SetCameraToShootPosition;
        
        public void Handle(IUIButton uiButton) =>
            _cameraService.SetPosition(PositionId.ShootPosition);
    }
}