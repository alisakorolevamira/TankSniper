using System;
using System.Threading;
using JetBrains.Annotations;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.Presentations.Views.Enemies.Helicopter;
using Sources.Scripts.Presentations.Views.Enemies.Jeep;
using Sources.Scripts.Presentations.Views.Enemies.Standing;
using Sources.Scripts.Presentations.Views.Enemies.Tank;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopter;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Jeep;
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
        private readonly IJeepEnemySpawnerService _jeepEnemySpawnerService;
        private readonly IBossEnemySpawnerService _bossEnemySpawnerService;

        private CancellationTokenSource _cancellationTokenSource;

        public EnemySpawnerPresenter(
            KilledEnemiesCounter killedEnemiesCounter,
            EnemySpawner enemySpawner,
            IEnemySpawnerView enemySpawnerView,
            ITankEnemySpawnerService tankEnemySpawnerService,
            IStandingEnemySpawnerService standingEnemySpawnerService,
            IHelicopterEnemySpawnerService helicopterEnemySpawnerService,
            IJeepEnemySpawnerService jeepEnemySpawnerService,
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
            _jeepEnemySpawnerService = jeepEnemySpawnerService ?? throw new ArgumentNullException(nameof(jeepEnemySpawnerService));
            _bossEnemySpawnerService = bossEnemySpawnerService ??
                                       throw new ArgumentNullException(nameof(bossEnemySpawnerService));
        }

        public override void Enable() => 
            SpawnEnemy();

        private void SpawnEnemy()
        {
            foreach (TankEnemyView tank in _enemySpawnerView.Tanks)
            {
                ITankEnemyView tankEnemyView = _tankEnemySpawnerService.Spawn(_killedEnemiesCounter, tank);
                    
                tankEnemyView.SetPlayerHealthView(_enemySpawnerView.PlayerView.PlayerHealthView);
                _enemySpawner.SpawnedEnemies++;
            }

            foreach (HelicopterEnemyView helicopter in _enemySpawnerView.Helicopters)
            {
                IHelicopterEnemyView view = _helicopterEnemySpawnerService.Spawn(_killedEnemiesCounter, helicopter);
                
                view.SetPlayerHealthView(_enemySpawnerView.PlayerView.PlayerHealthView);
                _enemySpawner.SpawnedEnemies++;
            }

            foreach (StandingEnemyView standing in _enemySpawnerView.Standings)
            {
                IStandingEnemyView view = _standingEnemySpawnerService.Spawn(_killedEnemiesCounter, standing);
                
                view.SetPlayerHealthView(_enemySpawnerView.PlayerView.PlayerHealthView);
                _enemySpawner.SpawnedEnemies++;
            }
            
            foreach (JeepEnemyView jeep in _enemySpawnerView.Jeeps)
            {
                IJeepEnemyView view = _jeepEnemySpawnerService.Spawn(_killedEnemiesCounter, jeep);
                
                view.SetPlayerHealthView(_enemySpawnerView.PlayerView.PlayerHealthView);
                _enemySpawner.SpawnedEnemies++;
            }
        }
    }
}