using System;
using Sources.Scripts.Presentations.Views;
using Sources.Scripts.PresentationsInterfaces.Views.ObjectPool;

namespace Sources.Scripts.InfrastructureInterfaces.Services.ObjectPool
{
    public interface IObjectPool
    {
        event Action<int> ObjectCountChanged;

        T Get<T>()
            where T : View;

        void Return(PoolableObject poolableObject);
    }
}