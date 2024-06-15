﻿using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Standing;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners
{
    public interface IStandingEnemySpawnerService
    {
        IStandingEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, IEnemySpawnPoint spawnPoint);
    }
}