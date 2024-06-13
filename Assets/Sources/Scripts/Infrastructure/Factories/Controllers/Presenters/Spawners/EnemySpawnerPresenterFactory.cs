using System;
using System.Collections.Generic;
using Sources.Scripts.Controllers.Presenters.Spawners;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Spawners
{
    public class EnemySpawnerPresenterFactory
    {
        private readonly IEnemySpawnerService _enemySpawnerService;
        private readonly IBossEnemySpawnerService _bossEnemySpawnerService;

        public EnemySpawnerPresenterFactory(
            IEnemySpawnerService enemySpawnerService,
            IBossEnemySpawnerService bossEnemySpawnerService)
        {
            _enemySpawnerService = enemySpawnerService ?? throw new ArgumentNullException(nameof(enemySpawnerService));
            _bossEnemySpawnerService = bossEnemySpawnerService ??
                                     throw new ArgumentNullException(nameof(bossEnemySpawnerService));
        }

        public EnemySpawnerPresenter Create(
            EnemySpawner enemySpawner,
            KilledEnemiesCounter killedEnemiesCounter,
            IEnemySpawnerView enemySpawnerView)
        {
            return new EnemySpawnerPresenter(
                killedEnemiesCounter,
                enemySpawner,
                enemySpawnerView,
                _enemySpawnerService,
                _bossEnemySpawnerService);
        }
    }
}