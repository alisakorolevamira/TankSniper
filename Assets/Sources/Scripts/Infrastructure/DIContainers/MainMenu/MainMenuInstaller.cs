using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Scenes;
using Sources.Scripts.Infrastructure.Factories.Views.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.MainMenu;
using Sources.Scripts.Infrastructure.Services.PauseServices;
using Sources.Scripts.Infrastructure.Services.Tutorials;
using Sources.Scripts.InfrastructureInterfaces.Services.PauseServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;
using Sources.Scripts.InfrastructureInterfaces.Services.Upgrades;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.Presentations.Views;
using Sources.Scripts.UIFramework.Presentations.Views;
using Sources.Scripts.UIFramework.Services.Focus;
using Sources.Scripts.UIFramework.ServicesInterfaces.Focus;
using UnityEngine;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.MainMenu
{
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] private MainMenuHud _mainMenuHud;
        [SerializeField] private ContainerView _containerView;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MainMenuHud>().FromInstance(_mainMenuHud).AsSingle();
            Container.Bind<ContainerView>().FromInstance(_containerView).AsSingle();
            Container.Bind<UICollector>().FromInstance(_mainMenuHud.UICollector).AsSingle();
            Container.BindInterfacesAndSelfTo<MainMenuSceneFactory>().AsSingle();
            
            BindServices();
            BindLevelAvailability();
            BindMainMenuLoadService();
        }
        
        private void BindServices()
        {
            Container.Bind<IPauseService>().To<PauseService>().AsSingle();
            //Container.Bind<IEnemySpawnerConfigCollectionService>().To<EnemySpawnerConfigCollectionService>().AsSingle();
            //Container.Bind<IStickyService>().To<StickyService>().AsSingle();
            //Container.Bind<IUpgradeConfigCollectionService>().To<UpgradeConfigCollectionService>().AsSingle();
            Container.Bind<ITutorialService>().To<TutorialService>().AsSingle();
        }

        private void BindMainMenuLoadService()
        {
            Container.Bind<CreateMainMenuSceneService>().AsSingle();
            Container.Bind<LoadMainMenuSceneService>().AsSingle();
        }
        
        private void BindLevelAvailability()
        {
            Container.Bind<LevelAvailabilityPresenterFactory>().AsSingle();
            Container.Bind<LevelAvailabilityViewFactory>().AsSingle();
        }
    }
}