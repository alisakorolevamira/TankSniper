using Sources.Scripts.ControllersInterfaces.ControllerLifetimes;
using Sources.Scripts.DomainInterfaces.Models.Gameplay;
using Sources.Scripts.DomainInterfaces.Models.Spawners;

namespace Sources.Scripts.InfrastructureInterfaces.Services.LevelCompleted
{
    public interface ILevelCompletedService : IEnable, IDisable
    {
        bool AllEnemiesKilled { get; }
        public void Register(IKilledEnemiesCounter killedEnemiesCounter, IEnemySpawner enemySpawner);
    }
}