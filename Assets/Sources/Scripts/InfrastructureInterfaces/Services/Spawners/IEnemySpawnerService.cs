using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners
{
    public interface IEnemySpawnerService
    {
        IEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, IEnemySpawnPoint spawnPoint);
    }
}