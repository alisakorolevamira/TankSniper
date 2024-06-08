using Sources.Scripts.Infrastructure.Services.Audio;
using Sources.Scripts.Infrastructure.Services.PauseServices;
using Sources.Scripts.Infrastructure.Services.SceneLoaderServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.PauseServices;
using Sources.Scripts.InfrastructureInterfaces.Services.SceneLoaderServices;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Projects
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneLoaderService>().To<SceneLoaderService>().AsSingle();
            Container.Bind<IVolumeService>().To<VolumeService>().AsSingle();
            Container.Bind<IPauseService>().To<PauseService>().AsSingle();
        }
    }
}