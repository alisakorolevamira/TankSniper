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
        private readonly ITankEnemySpawnerService _tankEnemySpawnerService;
        private readonly IBossEnemySpawnerService _bossEnemySpawnerService;
        private readonly IStandingEnemySpawnerService _standingEnemySpawnerService;

        public EnemySpawnerPresenterFactory(
            ITankEnemySpawnerService tankEnemySpawnerService,
            IBossEnemySpawnerService bossEnemySpawnerService,
            IStandingEnemySpawnerService standingEnemySpawnerService)
        {
            _tankEnemySpawnerService = tankEnemySpawnerService ?? throw new ArgumentNullException(nameof(tankEnemySpawnerService));
            _standingEnemySpawnerService = standingEnemySpawnerService ??
                                           throw new ArgumentNullException(nameof(standingEnemySpawnerService));
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
                _tankEnemySpawnerService,
                _standingEnemySpawnerService,
                _bossEnemySpawnerService);
        }
    }
}