using System;
using Sources.Scripts.Controllers.Presenters.Cameras;
using Sources.Scripts.InfrastructureInterfaces.Services.Cameras;
using Sources.Scripts.PresentationsInterfaces.Views.Cameras;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Cameras
{
    public class CameraPresenterFactory
    {
        private readonly ICameraService _cameraService;

        public CameraPresenterFactory(ICameraService cameraService)
        {
            _cameraService = cameraService ?? throw new ArgumentNullException(nameof(cameraService));
        }
        
        public CameraPresenter Create(ICameraView cameraView)
        {
            return new CameraPresenter(cameraView, _cameraService);
        }
    }
}