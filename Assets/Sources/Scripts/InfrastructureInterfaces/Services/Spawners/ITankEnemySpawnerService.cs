﻿using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners
{
    public interface ITankEnemySpawnerService
    {
        ITankEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, IEnemySpawnPoint spawnPoint);
    }
}