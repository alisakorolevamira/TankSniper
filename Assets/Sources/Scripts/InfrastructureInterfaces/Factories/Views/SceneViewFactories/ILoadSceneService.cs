using Sources.Scripts.DomainInterfaces.Models.Payloads;

namespace Sources.Scripts.InfrastructureInterfaces.Factories.Views.SceneViewFactories
{
    public interface ILoadSceneService
    {
        void Load(IScenePayload scenePayload);
    }
}