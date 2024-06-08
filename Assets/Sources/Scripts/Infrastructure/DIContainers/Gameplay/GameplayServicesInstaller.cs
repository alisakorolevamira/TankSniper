using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Gameplay
{
    public class GameplayServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Container.Bind<ISaveService>().To<SaveService>().AsSingle();
            //Container.Bind<ILevelCompletedService>().To<LevelCompletedService>().AsSingle();
            //Container.Bind<ITutorialService>().To<TutorialService>().AsSingle();
            //Container.Bind<IGameOverService>().To<GameOverService>().AsSingle();
            
            //Container.Bind<KillEnemyCounterPresenterFactory>().AsSingle();
            //Container.Bind<KillEnemyCounterViewFactory>().AsSingle();
            //Container.Bind<InterstitialShowerPresenterFactory>().AsSingle();
            //Container.Bind<InterstitialShowerViewFactory>().AsSingle();
        }
    }
}