using Cysharp.Threading.Tasks;
using Sources.Scripts.ControllersInterfaces.ControllerLifetimes;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices.Methods;

namespace Sources.Scripts.InfrastructureInterfaces.Services.SceneServices
{
    public interface ISceneService : IUpdatable, IFixedUpdatable, ILateUpdatable, IDisable
    {
        UniTask ChangeSceneAsync(string sceneName, object payload = null);
    }
}