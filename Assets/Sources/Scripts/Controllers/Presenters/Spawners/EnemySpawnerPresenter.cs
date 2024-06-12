using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.Presentations.Views.Common;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Common;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.Spawners
{
    public class EnemySpawnerPresenter : PresenterBase
    {
        private readonly EnemySpawner _enemySpawner;
        private readonly KilledEnemiesCounter _killedEnemiesCounter;
        private readonly IEnemySpawnerView _enemySpawnerView;
        private readonly IEnemySpawnerService _enemySpawnerService;
        private readonly IBossEnemySpawnerService _bossEnemySpawnerService;

        private CancellationTokenSource _cancellationTokenSource;

        public EnemySpawnerPresenter(
            KilledEnemiesCounter killedEnemiesCounter,
            EnemySpawner enemySpawner,
            IEnemySpawnerView enemySpawnerView,
            IEnemySpawnerService enemySpawnerService,
            IBossEnemySpawnerService bossEnemySpawnerService)
        {
            _killedEnemiesCounter = killedEnemiesCounter ?? throw new ArgumentNullException(nameof(killedEnemiesCounter));
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
            _enemySpawnerView = enemySpawnerView ?? throw new ArgumentNullException(nameof(enemySpawnerView));
            _enemySpawnerService = enemySpawnerService ?? throw new ArgumentNullException(nameof(enemySpawnerService));
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
            IEnemyView enemyView = _enemySpawnerService.Spawn(_killedEnemiesCounter, spawnPoint);
            enemyView.SetPlayerHealthView(playerView.PlayerHealthView);

            _enemySpawner.SpawnedEnemies++;
        }

        private void SpawnBoss(Vector3 position, PlayerView playerView)
        {
            
        }
    }
}