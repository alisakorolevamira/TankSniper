using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Sources.Scripts.App.Core;
using Sources.Scripts.ControllersInterfaces.Scenes;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Scenes;
using Sources.Scripts.Infrastructure.Services.SceneServices;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Sources.Scripts.Infrastructure.Factories.App
{
    public class AppCoreFactory
    {
        public AppCore Create()
        {
            AppCore appCore = new GameObject(nameof(AppCore)).AddComponent<AppCore>();
            
            ProjectContext projectContext = Object.FindObjectOfType<ProjectContext>();
            
            //добавить curtain
            
            Dictionary<string, Func<object, SceneContext, UniTask<IScene>>> sceneFactories =
                new Dictionary<string, Func<object, SceneContext, UniTask<IScene>>>();
            SceneService sceneService = new SceneService(sceneFactories);
            projectContext.Container.BindInterfacesAndSelfTo<SceneService>().FromInstance(sceneService);
            
            sceneFactories["MainMenu"] = (payload, sceneContext) =>
                sceneContext.Container.Resolve<MainMenuSceneFactory>().Create(payload);
            sceneFactories["FirstLevel"] = (payload, sceneContext) =>
                sceneContext.Container.Resolve<GameplaySceneFactory>().Create(payload);
            
            return appCore;
        }
    }
}