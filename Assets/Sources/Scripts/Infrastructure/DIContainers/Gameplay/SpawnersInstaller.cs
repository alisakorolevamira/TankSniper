using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Spawners;
using Sources.Scripts.Infrastructure.Factories.Views.Spawners;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Gameplay
{
    public class SpawnersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Container
            //    .Bind<EnemySpawnerConfigContainer>()
            //    .FromResource(PrefabPath.EnemySpawnerConfigContainer)
            //    .AsSingle();

           // Container.Bind<IEnemySpawnerConfigCollectionService>().To<EnemySpawnerConfigCollectionService>().AsSingle();

            Container.Bind<EnemySpawnerPresenterFactory>().AsSingle();
            Container.Bind<EnemySpawnerViewFactory>().AsSingle();
        }
    }
}