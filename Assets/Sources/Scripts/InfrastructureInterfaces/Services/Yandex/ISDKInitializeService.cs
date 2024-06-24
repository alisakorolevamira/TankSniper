using Cysharp.Threading.Tasks;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Yandex
{
    public interface ISDKInitializeService
    {
        void GameReady();
        void EnableCallbackLogging();
        UniTask Initialize();
    }
}