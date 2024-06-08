using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Scenes;
using Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.Gameplay;
using Sources.Scripts.Presentations.Views;
using Sources.Scripts.Presentations.Views.RootGameObjects;
using Sources.Scripts.UIFramework.Presentations.Views;
using UnityEngine;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Gameplay
{
    public class GameplayInstaller : MonoInstaller
    {
        //[SerializeField] private GameplayHud _gameplayHud;
        [SerializeField] private RootGameObject _rootGameObject;
        [SerializeField] private ContainerView _containerView;
        
        public override void InstallBindings()
        {
            //Container.BindInterfacesAndSelfTo<GameplayHud>().FromInstance(_gameplayHud).AsSingle();
            //Container.Bind<UICollector>().FromInstance(_gameplayHud.UiCollector).AsSingle();
            Container.Bind<RootGameObject>().FromInstance(_rootGameObject).AsSingle();
            Container.Bind<ContainerView>().FromInstance(_containerView).AsSingle();
            Container.BindInterfacesAndSelfTo<GameplaySceneFactory>().AsSingle();
            
            BindServices();
        }

        private void BindServices()
        {
            //Container.BindInterfacesAndSelfTo<UpdateService>().AsSingle();
            //Container.BindInterfacesAndSelfTo<NewInputService>().AsSingle();
            //Container.Bind<LinecastService>().AsSingle();
            //Container.Bind<IOverlapService>().To<OverlapService>().AsSingle();
            Container.Bind<LoadGameplaySceneService>().AsSingle();
            Container.Bind<CreateGameplaySceneService>().AsSingle();
        }
    }
}