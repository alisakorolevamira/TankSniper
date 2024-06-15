using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Spawners;
using Sources.Scripts.Domain.Models.Spawners.Types;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.Presentations.Views.Common;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Common;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Standing;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.Spawners
{
    public class EnemySpawnerPresenter : PresenterBase
    {
        private readonly EnemySpawner _enemySpawner;
        private readonly KilledEnemiesCounter _killedEnemiesCounter;
        private readonly IEnemySpawnerView _enemySpawnerView;
        private readonly ITankEnemySpawnerService _tankEnemySpawnerService;
        private readonly IStandingEnemySpawnerService _standingEnemySpawnerService;
        private readonly IBossEnemySpawnerService _bossEnemySpawnerService;

        private CancellationTokenSource _cancellationTokenSource;

        public EnemySpawnerPresenter(
            KilledEnemiesCounter killedEnemiesCounter,
            EnemySpawner enemySpawner,
            IEnemySpawnerView enemySpawnerView,
            ITankEnemySpawnerService tankEnemySpawnerService,
            IStandingEnemySpawnerService standingEnemySpawnerService,
            IBossEnemySpawnerService bossEnemySpawnerService)
        {
            _killedEnemiesCounter = killedEnemiesCounter ?? throw new ArgumentNullException(nameof(killedEnemiesCounter));
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
            _enemySpawnerView = enemySpawnerView ?? throw new ArgumentNullException(nameof(enemySpawnerView));
            _tankEnemySpawnerService = tankEnemySpawnerService ?? throw new ArgumentNullException(nameof(tankEnemySpawnerService));
            _standingEnemySpawnerService = standingEnemySpawnerService ??
                                           throw new ArgumentNullException(nameof(standingEnemySpawnerService));
            _bossEnemySpawnerService = bossEnemySpawnerService ??
                                     throw new ArgumentNullException(nameof(bossEnemySpawnerService));
        }

        public override void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            Spawn(_cancellationTokenSource.Token);
        }

        public override void Disable() =>
            _cancellationTokenSource.Cancel();

        private void Spawn(CancellationToken cancellationToken)
        {
            try
            {
                foreach (IEnemySpawnPoint spawnPoint in _enemySpawnerView.SpawnPoints)
                {
                    SpawnEnemy(spawnPoint, _enemySpawnerView.PlayerView);
                    //SpawnBoss(spawnPoint.Position, _enemySpawnerView.PlayerView);
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void SpawnEnemy(IEnemySpawnPoint spawnPoint, PlayerView playerView)
        {
            if (spawnPoint.EnemyType == EnemyType.Tank)
            {
                ITankEnemyView tankEnemyView = _tankEnemySpawnerService.Spawn(_killedEnemiesCounter, spawnPoint);
                tankEnemyView.SetPlayerHealthView(playerView.PlayerHealthView);
            }
            
            else if (spawnPoint.EnemyType == EnemyType.Standing)
            {
                IStandingEnemyView standingEnemyView =
                    _standingEnemySpawnerService.Spawn(_killedEnemiesCounter, spawnPoint);
                
                standingEnemyView.SetPlayerHealthView(playerView.PlayerHealthView);
            }

            _enemySpawner.SpawnedEnemies++;
        }

        private void SpawnBoss(Vector3 position, PlayerView playerView)
        {
            
        }
    }
}