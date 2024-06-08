using Cysharp.Threading.Tasks;

namespace Sources.Scripts.InfrastructureInterfaces.Services.SceneLoaderServices
{
    public interface ISceneLoaderService
    {
        UniTask LoadSceneAsync(string sceneName);
    }
}