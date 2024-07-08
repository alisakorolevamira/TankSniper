using System;
using System.Threading;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Boat;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Bosses;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Dron;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Helicopter;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Jeep;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Stickmen;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Tanks;
using Sources.Scripts.Presentations.Views.Enemies.Boat;
using Sources.Scripts.Presentations.Views.Enemies.Bosses;
using Sources.Scripts.Presentations.Views.Enemies.Dron;
using Sources.Scripts.Presentations.Views.Enemies.Helicopter;
using Sources.Scripts.Presentations.Views.Enemies.Jeep;
using Sources.Scripts.Presentations.Views.Enemies.Standing;
using Sources.Scripts.Presentations.Views.Enemies.Tanks;
using Sources.Scripts.Presentations.Views.Enemies.WalkingEnemy;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boat;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Bosses;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Dron;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopter;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Jeep;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.MovingEnemy;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Standing;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tanks;
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
        private readonly IRobotBossEnemySpawnerService _robotBossEnemySpawnerService;
        private readonly IDronEnemySpawnerService _dronEnemySpawnerService;
        private readonly IWalkingEnemySpawnerService _walkingEnemySpawnerService;
        private readonly IBoatEnemySpawnerService _boatEnemySpawnerService;
        private readonly IStandingTankEnemySpawnerService _standingTankEnemySpawnerService;
        private readonly IBoatBossEnemySpawnerService _boatBossEnemySpawnerService;

        private CancellationTokenSource _cancellationTokenSource;

        public EnemySpawnerPresenter(
            KilledEnemiesCounter killedEnemiesCounter,
            EnemySpawner enemySpawner,
            IEnemySpawnerView enemySpawnerView,
            ITankEnemySpawnerService tankEnemySpawnerService,
            IStandingEnemySpawnerService standingEnemySpawnerService,
            IHelicopterEnemySpawnerService helicopterEnemySpawnerService,
            IJeepEnemySpawnerService jeepEnemySpawnerService,
            IRobotBossEnemySpawnerService robotBossEnemySpawnerService,
            IDronEnemySpawnerService dronEnemySpawnerService,
            IWalkingEnemySpawnerService walkingEnemySpawnerService,
            IBoatEnemySpawnerService boatEnemySpawnerService,
            IStandingTankEnemySpawnerService standingTankEnemySpawnerService,
            IBoatBossEnemySpawnerService boatBossEnemySpawnerService)
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
            _robotBossEnemySpawnerService = robotBossEnemySpawnerService ??
                                                throw new ArgumentNullException(nameof(robotBossEnemySpawnerService));
            _dronEnemySpawnerService = dronEnemySpawnerService ??
                                       throw new ArgumentNullException(nameof(dronEnemySpawnerService));
            _walkingEnemySpawnerService = walkingEnemySpawnerService ??
                                              throw new ArgumentNullException(nameof(walkingEnemySpawnerService));
            _boatEnemySpawnerService = boatEnemySpawnerService ??
                                       throw new ArgumentNullException(nameof(boatEnemySpawnerService));
            _standingTankEnemySpawnerService = standingTankEnemySpawnerService ??
                                               throw new ArgumentNullException(nameof(standingTankEnemySpawnerService));
            _boatBossEnemySpawnerService = boatBossEnemySpawnerService ??
                                           throw new ArgumentNullException(nameof(boatBossEnemySpawnerService));
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

            foreach (DronEnemyView dron in _enemySpawnerView.Drons)
            {
                IDronEnemyView view = _dronEnemySpawnerService.Spawn(_killedEnemiesCounter, dron);
                
                SetPlayerHealthView(view);
            }
            
            foreach (WalkingEnemyView moving in _enemySpawnerView.Walkings)
            {
                IWalkingEnemyView view = _walkingEnemySpawnerService.Spawn(_killedEnemiesCounter, moving);
                
                SetPlayerHealthView(view);
            }
            
            foreach (StandingTankEnemyView tank in _enemySpawnerView.StandingTanks)
            {
                IStandingTankEnemyView view = _standingTankEnemySpawnerService.Spawn(_killedEnemiesCounter, tank);
                
                SetPlayerHealthView(view);
            }
            
            foreach (BoatEnemyView boat in _enemySpawnerView.Boats)
            {
                IBoatEnemyView view = _boatEnemySpawnerService.Spawn(_killedEnemiesCounter, boat);
                
                SetPlayerHealthView(view);
            }
            
            foreach (RobotBossEnemyView robot in _enemySpawnerView.RobotBosses)
            {
                IRobotBossEnemyView view = _robotBossEnemySpawnerService.Spawn(_killedEnemiesCounter, robot);
                
                SetPlayerHealthView(view);
            }
            
            foreach (BoatBossEnemyView boat in _enemySpawnerView.BoatBosses)
            {
                IBoatBossEnemyView view = _boatBossEnemySpawnerService.Spawn(_killedEnemiesCounter, boat);
                
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