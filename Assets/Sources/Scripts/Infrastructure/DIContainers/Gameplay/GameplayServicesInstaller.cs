using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Gameplay;
using Sources.Scripts.Infrastructure.Services.GameOver;
using Sources.Scripts.Infrastructure.Services.LevelCompleted;
using Sources.Scripts.InfrastructureInterfaces.Services.GameOver;
using Sources.Scripts.InfrastructureInterfaces.Services.LevelCompleted;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Gameplay
{
    public class GameplayServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ILevelCompletedService>().To<LevelCompletedService>().AsSingle();
            Container.Bind<IGameOverService>().To<GameOverService>().AsSingle();
            
            Container.Bind<KilledEnemiesCounterPresenterFactory>().AsSingle();
            Container.Bind<KilledEnemiesCounterViewFactory>().AsSingle();
        }
    }
}