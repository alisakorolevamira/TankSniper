using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Sources.Scripts.App.Core;
using Sources.Scripts.ControllersInterfaces.Scenes;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Scenes;
using Sources.Scripts.Infrastructure.Services.SceneServices;
using Sources.Scripts.InfrastructureInterfaces.Services.SceneLoaderServices;
using Sources.Scripts.Presentations.UI.Curtain;
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
            
            LoadingCurtainView curtainView =
                Object.Instantiate(Resources.Load<LoadingCurtainView>(PrefabPath.Curtain)) ??
                throw new NullReferenceException(nameof(LoadingCurtainView));
            
            projectContext.Container.Bind<LoadingCurtainView>().FromInstance(curtainView);
            
            //curtainView.Hide();
            
            Dictionary<string, Func<object, SceneContext, UniTask<IScene>>> sceneFactories =
                new Dictionary<string, Func<object, SceneContext, UniTask<IScene>>>();
            SceneService sceneService = new SceneService(sceneFactories);
            projectContext.Container.BindInterfacesAndSelfTo<SceneService>().FromInstance(sceneService);
            
            sceneFactories[LevelConst.MainMenu] = (payload, sceneContext) =>
                sceneContext.Container.Resolve<MainMenuSceneFactory>().Create(payload);
            sceneFactories[LevelConst.FirstLevel] = (payload, sceneContext) =>
                sceneContext.Container.Resolve<GameplaySceneFactory>().Create(payload);
            sceneFactories[LevelConst.SecondLevel] = (payload, sceneContext) =>
                sceneContext.Container.Resolve<GameplaySceneFactory>().Create(payload);
            sceneFactories[LevelConst.ThirdLevel] = (payload, sceneContext) =>
                sceneContext.Container.Resolve<GameplaySceneFactory>().Create(payload);
            sceneFactories[LevelConst.FourthLevel] = (payload, sceneContext) =>
                sceneContext.Container.Resolve<GameplaySceneFactory>().Create(payload);
            sceneFactories[LevelConst.FifthLevel] = (payload, sceneContext) =>
                sceneContext.Container.Resolve<GameplaySceneFactory>().Create(payload);
            sceneFactories[LevelConst.SixthLevel] = (payload, sceneContext) =>
                sceneContext.Container.Resolve<GameplaySceneFactory>().Create(payload);
            sceneFactories[LevelConst.SeventhLevel] = (payload, sceneContext) =>
                sceneContext.Container.Resolve<GameplaySceneFactory>().Create(payload);
            sceneFactories[LevelConst.EighthLevel] = (payload, sceneContext) =>
                sceneContext.Container.Resolve<GameplaySceneFactory>().Create(payload);
            
            sceneService.AddBeforeSceneChangeHandler(async _ => await curtainView.ShowCurtain());
            
            sceneService.AddBeforeSceneChangeHandler(async sceneName => 
                await projectContext.Container.Resolve<ISceneLoaderService>().LoadSceneAsync(sceneName));
            
            appCore.Construct(sceneService);
            
            return appCore;
        }
    }
}