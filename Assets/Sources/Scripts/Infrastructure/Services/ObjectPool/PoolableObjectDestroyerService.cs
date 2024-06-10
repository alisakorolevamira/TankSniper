using Sources.Scripts.InfrastructureInterfaces.Services.ObjectPool;
using Sources.Scripts.Presentations.Views;
using Sources.Scripts.PresentationsInterfaces.Views.ObjectPool;

namespace Sources.Scripts.Infrastructure.Services.ObjectPool
{
    public class PoolableObjectDestroyerService : IPoolableObjectDestroyerService
    {
        public void Destroy(View view)
        {
            if (view.TryGetComponent(out PoolableObject poolableObject) == false)
            {
                view.Destroy();

                return;
            }

            poolableObject.ReturnToPool();
            view.Hide();
        }
    }
}