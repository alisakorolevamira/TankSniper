﻿using Sources.Scripts.Domain.Models.Gameplay.Configs;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.MainMenu;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Scenes;
using Sources.Scripts.Infrastructure.Factories.Views.MainMenu;
using Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.MainMenu;
using Sources.Scripts.Infrastructure.Services.PauseServices;
using Sources.Scripts.Infrastructure.Services.Tutorials;
using Sources.Scripts.Infrastructure.Services.UpgradeServices;
using Sources.Scripts.InfrastructureInterfaces.Services.PauseServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;
using Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.Presentations.Views;
using Sources.Scripts.Presentations.Views.RootGameObjects;
using UnityEngine;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.MainMenu
{
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] private MainMenuRootGameObjects _mainMenuRoot;
        [SerializeField] private MainMenuHud _mainMenuHud;
        [SerializeField] private ContainerView _containerView;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MainMenuHud>().FromInstance(_mainMenuHud).AsSingle();
            Container.Bind<ContainerView>().FromInstance(_containerView).AsSingle();
            Container.Bind<MainMenuRootGameObjects>().FromInstance(_mainMenuRoot).AsSingle();
            Container.BindInterfacesAndSelfTo<MainMenuSceneFactory>().AsSingle();
            
            BindServices();
            BindMainMenuLoadService();
            BindConfigs();
            BindFactories();
        }
        
        private void BindServices()
        {
            Container.Bind<IPauseService>().To<PauseService>().AsSingle();
            Container.Bind<ITutorialService>().To<TutorialService>().AsSingle();
            Container.Bind<IUpgradeService>().To<UpgradeService>().AsSingle();
        }

        private void BindMainMenuLoadService()
        {
            Container.Bind<CreateMainMenuSceneService>().AsSingle();
            Container.Bind<LoadMainMenuSceneService>().AsSingle();
        }

        private void BindConfigs()
        {
            Container
                .Bind<LocationSpritesConfig>()
                .FromResource("Configs/LocationSpritesConfig")
                .AsSingle();
        }

        private void BindFactories()
        {
            Container.Bind<MainMenuPresenterFactory>().AsSingle();
            Container.Bind<MainMenuViewFactory>().AsSingle();
        }
    }
}