using Sources.Scripts.Infrastructure.Services.LoadServices;
using Sources.Scripts.Infrastructure.Services.LoadServices.Data;
using Sources.Scripts.Infrastructure.Services.Repositories;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices.Data;
using Sources.Scripts.InfrastructureInterfaces.Services.Repositories;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Common
{
    public class LoadServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ILoadService>().To<LoadService>().AsSingle();
            Container.Bind<IDataService>().To<PlayerPrefsDataService>().AsSingle();
            Container.Bind<IEntityRepository>().To<EntityRepository>().AsSingle();
        }
    }
}