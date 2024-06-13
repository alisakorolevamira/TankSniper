﻿using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.Scripts.InfrastructureInterfaces.Services.ObjectPool.Generic;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Scripts.Infrastructure.Services.Spawners
{
    public class EnemySpawnerService : IEnemySpawnerService
    {
        private readonly IEnemyViewFactory _enemyViewFactory;

        public EnemySpawnerService(
            IEnemyViewFactory enemyViewFactory)
        {
            _enemyViewFactory = enemyViewFactory ?? throw new ArgumentNullException(nameof(enemyViewFactory));
        }

        public ITankEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, IEnemySpawnPoint spawnPoint)
        {
            Enemy enemy = new Enemy(new EnemyHealth(EnemyConst.Health), new EnemyAttacker(EnemyConst.Damage), spawnPoint.EnemyType);

            ITankEnemyView tankEnemyView = _enemyViewFactory.Create(enemy, killedEnemiesCounter, spawnPoint);

            tankEnemyView.DisableNavmeshAgent();
            tankEnemyView.SetPosition(spawnPoint.Position);
            tankEnemyView.EnableNavmeshAgent();
            tankEnemyView.Show();

            return tankEnemyView;
        }
    }
}