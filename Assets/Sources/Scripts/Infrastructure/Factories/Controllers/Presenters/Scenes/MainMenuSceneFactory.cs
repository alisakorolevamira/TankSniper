using Cysharp.Threading.Tasks;
using Sources.Scripts.ControllersInterfaces.Scenes;
using Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.MainMenu;
using Sources.Scripts.InfrastructureInterfaces.Factories.Controllers.Scenes;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Scenes
{
    public class MainMenuSceneFactory : ISceneFactory
    {
        private readonly CreateMainMenuSceneService _createMainMenuSceneService;
        
        public UniTask<IScene> Create(object payload)
        {
            throw new System.NotImplementedException();
        }
    }
}