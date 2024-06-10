using Sources.Scripts.Presentations.Views;

namespace Sources.Scripts.InfrastructureInterfaces.Services.ObjectPool
{
    public interface IPoolableObjectDestroyerService
    {
        void Destroy(View view);
    }
}