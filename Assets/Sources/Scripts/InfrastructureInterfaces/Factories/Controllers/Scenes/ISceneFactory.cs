using Cysharp.Threading.Tasks;
using Sources.Scripts.ControllersInterfaces.Scenes;

namespace Sources.Scripts.InfrastructureInterfaces.Factories.Controllers.Scenes
{
    public interface ISceneFactory
    {
        UniTask<IScene> Create(object payload);
    }
}