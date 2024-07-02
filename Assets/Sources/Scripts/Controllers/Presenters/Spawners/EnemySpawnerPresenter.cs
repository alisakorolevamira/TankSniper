using System;
using System.Threading;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Spawners;
using Sources.Scripts.Domain.Models.Spawners.Types;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopter;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Standing;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;

namespace Sources.Scripts.Controllers.Presenters.Spawners
{
    public class EnemySpawnerPresenter : PresenterBase
    {
        private readonly EnemySpawner _enemySpawner;
        private readonly KilledEnemiesCounter _killedEnemiesCounter;
        private readonly IEnemySpawnerView _enemySpawnerView;
        private readonly ITankEnemySpawnerService _tankEnemySpawnerService;
        private readonly IStandingEnemySpawnerService _standingEnemySpawnerService;
        private readonly IHelicopterEnemySpawnerService _helicopterEnemySpawnerService;
        private readonly IBossEnemySpawnerService _bossEnemySpawnerService;

        private CancellationTokenSource _cancellationTokenSource;

        public EnemySpawnerPresenter(
            KilledEnemiesCounter killedEnemiesCounter,
            EnemySpawner enemySpawner,
            IEnemySpawnerView enemySpawnerView,
            ITankEnemySpawnerService tankEnemySpawnerService,
            IStandingEnemySpawnerService standingEnemySpawnerService,
            IHelicopterEnemySpawnerService helicopterEnemySpawnerService,
            IBossEnemySpawnerService bossEnemySpawnerService)
        {
            _killedEnemiesCounter = killedEnemiesCounter ?? throw new ArgumentNullException(nameof(killedEnemiesCounter));
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
            _enemySpawnerView = enemySpawnerView ?? throw new ArgumentNullException(nameof(enemySpawnerView));
            _tankEnemySpawnerService = tankEnemySpawnerService ?? throw new ArgumentNullException(nameof(tankEnemySpawnerService));
            _standingEnemySpawnerService = standingEnemySpawnerService ??
                                           throw new ArgumentNullException(nameof(standingEnemySpawnerService));
            _helicopterEnemySpawnerService = helicopterEnemySpawnerService ??
                                            throw new ArgumentNullException(nameof(helicopterEnemySpawnerService));
            _bossEnemySpawnerService = bossEnemySpawnerService ??
                                     throw new ArgumentNullException(nameof(bossEnemySpawnerService));
        }

        public override void Enable() => 
            SpawnEnemy();

        private void SpawnEnemy()
        {
            foreach (var enemyView in _enemySpawnerView.EnemyViews)
            {
                if (enemyView.EnemyType == EnemyType.Tank)
                {
                    ITankEnemyView tankEnemyView = _tankEnemySpawnerService.Spawn(_killedEnemiesCounter, enemyView);
                    
                    tankEnemyView.SetPlayerHealthView(_enemySpawnerView.PlayerView.PlayerHealthView);
                }
                    
                else if (enemyView.EnemyType == EnemyType.Standing)
                {
                    IStandingEnemyView standingEnemyView =
                        _standingEnemySpawnerService.Spawn(_killedEnemiesCounter, enemyView);
                    
                    standingEnemyView.SetPlayerHealthView(_enemySpawnerView.PlayerView.PlayerHealthView);
                }
                
                else if (enemyView.EnemyType == EnemyType.Helicopter)
                {
                    IHelicopterEnemyView helicopterEnemyView =
                        _helicopterEnemySpawnerService.Spawn(_killedEnemiesCounter, enemyView);
                
                    helicopterEnemyView.SetPlayerHealthView(_enemySpawnerView.PlayerView.PlayerHealthView);
                }

                _enemySpawner.SpawnedEnemies++;
            }
        }
    }
}