using System;
using Sources.Scripts.ControllersInterfaces.ControllerLifetimes;
using Sources.Scripts.DomainInterfaces.Models.Gameplay;
using Sources.Scripts.DomainInterfaces.Models.Spawners;

namespace Sources.Scripts.InfrastructureInterfaces.Services.LevelCompleted
{
    public interface ILevelCompletedService : IEnable, IDisable
    {
        event Action<int> LevelCompleted;
        bool AllEnemiesKilled { get; }
        public void Register(IKilledEnemiesCounter killedEnemiesCounter, IEnemySpawner enemySpawner);
    }
}