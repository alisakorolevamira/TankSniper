using Sources.Scripts.InfrastructureInterfaces.Services.ObjectPool;
using Sources.Scripts.Presentations.Views;


namespace Sources.Scripts.PresentationsInterfaces.Views.ObjectPool
{
    public class PoolableObject : View
    {
        private IObjectPool _pool;

        public PoolableObject SetPool(IObjectPool pool)
        {
            _pool = pool;

            return this;
        }

        public void ReturnToPool() =>
            _pool.Return(this);
    }
}