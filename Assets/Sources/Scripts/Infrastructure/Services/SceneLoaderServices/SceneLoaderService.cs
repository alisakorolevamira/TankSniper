using Cysharp.Threading.Tasks;
using Sources.Scripts.InfrastructureInterfaces.Services.SceneLoaderServices;
using UnityEngine.SceneManagement;

namespace Sources.Scripts.Infrastructure.Services.SceneLoaderServices
{
    public class SceneLoaderService : ISceneLoaderService
    {
        public async UniTask LoadSceneAsync(string sceneName) =>
            await SceneManager.LoadSceneAsync(sceneName);
    }
}