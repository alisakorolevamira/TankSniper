using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Scenes;
using Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.Gameplay;
using Sources.Scripts.Infrastructure.Services.InputServices;
using Sources.Scripts.Infrastructure.Services.UpdateServices;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.Presentations.Views;
using Sources.Scripts.Presentations.Views.RootGameObjects;
using UnityEngine;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Gameplay
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private GameplayHud _gameplayHud;
        [SerializeField] private GameplayRootGameObject _gameplayRootGameObject;
        [SerializeField] private ContainerView _containerView;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameplayHud>().FromInstance(_gameplayHud).AsSingle();
            Container.Bind<GameplayRootGameObject>().FromInstance(_gameplayRootGameObject).AsSingle();
            Container.Bind<ContainerView>().FromInstance(_containerView).AsSingle();
            Container.BindInterfacesAndSelfTo<GameplaySceneFactory>().AsSingle();
            
            BindServices();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<UpdateService>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameplayInputService>().AsSingle();
            Container.Bind<LoadGameplaySceneService>().AsSingle();
            Container.Bind<CreateGameplaySceneService>().AsSingle();
        }
    }
}