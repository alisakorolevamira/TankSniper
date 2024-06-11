using Sources.Scripts.ControllersInterfaces.ControllerLifetimes;
using Sources.Scripts.DomainInterfaces.Models.Spawners;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Saves
{
    public interface ISaveService: IEnterable, IExitable
    {
        void Register(IEnemySpawner enemySpawner);
    }
}