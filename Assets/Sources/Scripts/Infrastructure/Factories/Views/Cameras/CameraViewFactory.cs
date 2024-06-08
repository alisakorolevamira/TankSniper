using System;
using Sources.Scripts.Controllers.Presenters.Cameras;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Cameras;
using Sources.Scripts.Presentations.Views.Cameras;
using Sources.Scripts.PresentationsInterfaces.Views.Cameras;

namespace Sources.Scripts.Infrastructure.Factories.Views.Cameras
{
    public class CameraViewFactory
    {
        private readonly CameraPresenterFactory _presenterFactory;

        public CameraViewFactory(CameraPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public ICinemachineCameraView Create(CinemachineCameraView cinemachineCameraView)
        {
            CameraPresenter presenter = _presenterFactory.Create(cinemachineCameraView);
            
            cinemachineCameraView.Construct(presenter);
            
            return cinemachineCameraView;
        }
    }
}