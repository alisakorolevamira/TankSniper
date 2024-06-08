using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Cameras;
using Sources.Scripts.Infrastructure.Factories.Views.Cameras;
using Sources.Scripts.Infrastructure.Services.Cameras;
using Sources.Scripts.InfrastructureInterfaces.Services.Cameras;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Gameplay
{
    public class CameraInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ICameraService>().To<CameraService>().AsSingle();
            Container.Bind<CameraPresenterFactory>().AsSingle();
            Container.Bind<CameraViewFactory>().AsSingle();
        }
    }
}