using System;
using System.Threading;
using JetBrains.Annotations;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies;
using Sources.Scripts.Presentations.Views.Enemies.Boss;
using Sources.Scripts.Presentations.Views.Enemies.Dron;
using Sources.Scripts.Presentations.Views.Enemies.Helicopter;
using Sources.Scripts.Presentations.Views.Enemies.Jeep;
using Sources.Scripts.Presentations.Views.Enemies.Standing;
using Sources.Scripts.Presentations.Views.Enemies.Tank;
using Sources.Scripts.Presentations.Views.Enemies.WalkingEnemy;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Dron;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopter;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Jeep;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.MovingEnemy;
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
        private readonly IDronEnemySpawnerService _dronEnemySpawnerService;
        private readonly IWalkingEnemySpawnerService walkingEnemySpawnerService;

        private CancellationTokenSource _cancellationTokenSource;

        public EnemySpawnerPresenter(
            KilledEnemiesCounter killedEnemiesCounter,
            EnemySpawner enemySpawner,
            IEnemySpawnerView enemySpawnerView,
            ITankEnemySpawnerService tankEnemySpawnerService,
            IStandingEnemySpawnerService standingEnemySpawnerService,
            IHelicopterEnemySpawnerService helicopterEnemySpawnerService,
            IJeepEnemySpawnerService jeepEnemySpawnerService,
            IBossEnemySpawnerService bossEnemySpawnerService,
            IDronEnemySpawnerService dronEnemySpawnerService,
            IWalkingEnemySpawnerService walkingEnemySpawnerService)
        {
            _killedEnemiesCounter = killedEnemiesCounter ??
                                    throw new ArgumentNullException(nameof(killedEnemiesCounter));
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
            _enemySpawnerView = enemySpawnerView ?? throw new ArgumentNullException(nameof(enemySpawnerView));
            _tankEnemySpawnerService = tankEnemySpawnerService ??
                                       throw new ArgumentNullException(nameof(tankEnemySpawnerService));
            _standingEnemySpawnerService = standingEnemySpawnerService ??
                                           throw new ArgumentNullException(nameof(standingEnemySpawnerService));
            _helicopterEnemySpawnerService = helicopterEnemySpawnerService ??
                                            throw new ArgumentNullException(nameof(helicopterEnemySpawnerService));
            _jeepEnemySpawnerService = jeepEnemySpawnerService ??
                                       throw new ArgumentNullException(nameof(jeepEnemySpawnerService));
            _bossEnemySpawnerService = bossEnemySpawnerService ??
                                       throw new ArgumentNullException(nameof(bossEnemySpawnerService));
            _dronEnemySpawnerService = dronEnemySpawnerService ??
                                       throw new ArgumentNullException(nameof(dronEnemySpawnerService));
            this.walkingEnemySpawnerService = walkingEnemySpawnerService ??
                                              throw new ArgumentNullException(nameof(walkingEnemySpawnerService));
        }

        public override void Enable() => 
            SpawnEnemy();

        private void SpawnEnemy()
        {
            foreach (TankEnemyView tank in _enemySpawnerView.Tanks)
            {
                ITankEnemyView view = _tankEnemySpawnerService.Spawn(_killedEnemiesCounter, tank);
                    
                SetPlayerHealthView(view);
            }

            foreach (HelicopterEnemyView helicopter in _enemySpawnerView.Helicopters)
            {
                IHelicopterEnemyView view = _helicopterEnemySpawnerService.Spawn(_killedEnemiesCounter, helicopter);
                
                SetPlayerHealthView(view);
            }

            foreach (StandingEnemyView standing in _enemySpawnerView.Standings)
            {
                IStandingEnemyView view = _standingEnemySpawnerService.Spawn(_killedEnemiesCounter, standing);
                
                SetPlayerHealthView(view);
            }
            
            foreach (JeepEnemyView jeep in _enemySpawnerView.Jeeps)
            {
                IJeepEnemyView view = _jeepEnemySpawnerService.Spawn(_killedEnemiesCounter, jeep);
                
                SetPlayerHealthView(view);
            }

            foreach (BossEnemyView boss in _enemySpawnerView.Bosses)
            {
                IBossEnemyView view = _bossEnemySpawnerService.Spawn(_killedEnemiesCounter, boss);
                
                SetPlayerHealthView(view);
            }

            foreach (DronEnemyView dron in _enemySpawnerView.Drons)
            {
                IDronEnemyView view = _dronEnemySpawnerService.Spawn(_killedEnemiesCounter, dron);
                
                SetPlayerHealthView(view);
            }
            
            foreach (WalkingEnemyView moving in _enemySpawnerView.Walkings)
            {
                IWalkingEnemyView view = walkingEnemySpawnerService.Spawn(_killedEnemiesCounter, moving);
                
                SetPlayerHealthView(view);
            }
        }

        private void SetPlayerHealthView(IEnemyViewBase view)
        {
            view.SetPlayerHealthView(_enemySpawnerView.PlayerView.PlayerHealthView);
            _enemySpawner.SpawnedEnemies++;
        }
    }
}