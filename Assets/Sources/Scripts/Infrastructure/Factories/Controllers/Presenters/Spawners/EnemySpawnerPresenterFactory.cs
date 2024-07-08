using System;
using Sources.Scripts.Controllers.Presenters.Spawners;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Bosses;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Dron;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Helicopter;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Jeep;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Stickmen;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Tanks;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Spawners
{
    public class EnemySpawnerPresenterFactory
    {
        private readonly ITankEnemySpawnerService _tankEnemySpawnerService;
        private readonly IRobotBossEnemySpawnerService _robotBossEnemySpawnerService;
        private readonly IStandingEnemySpawnerService _standingEnemySpawnerService;
        private readonly IJeepEnemySpawnerService _jeepEnemySpawnerService;
        private readonly IHelicopterEnemySpawnerService _helicopterEnemySpawnerService;
        private readonly IDronEnemySpawnerService _dronEnemySpawnerService;
        private readonly IWalkingEnemySpawnerService _walkingEnemySpawnerService;
        private readonly IStandingTankEnemySpawnerService _standingTankEnemySpawnerService;
        private readonly IBoatBossEnemySpawnerService _boatBossEnemySpawnerService;

        public EnemySpawnerPresenterFactory(
            ITankEnemySpawnerService tankEnemySpawnerService,
            IRobotBossEnemySpawnerService robotBossEnemySpawnerService,
            IStandingEnemySpawnerService standingEnemySpawnerService,
            IJeepEnemySpawnerService jeepEnemySpawnerService,
            IHelicopterEnemySpawnerService helicopterEnemySpawnerService,
            IDronEnemySpawnerService dronEnemySpawnerService,
            IWalkingEnemySpawnerService walkingEnemySpawnerService,
            IStandingTankEnemySpawnerService standingTankEnemySpawnerService,
            IBoatBossEnemySpawnerService boatBossEnemySpawnerService)
        {
            _tankEnemySpawnerService = tankEnemySpawnerService ??
                                       throw new ArgumentNullException(nameof(tankEnemySpawnerService));
            _standingEnemySpawnerService = standingEnemySpawnerService ??
                                           throw new ArgumentNullException(nameof(standingEnemySpawnerService));
            _jeepEnemySpawnerService = jeepEnemySpawnerService ??
                                       throw new ArgumentNullException(nameof(jeepEnemySpawnerService));
            _helicopterEnemySpawnerService = helicopterEnemySpawnerService ??
                                             throw new ArgumentNullException(nameof(helicopterEnemySpawnerService));
            _dronEnemySpawnerService = dronEnemySpawnerService ??
                                       throw new ArgumentNullException(nameof(dronEnemySpawnerService));
            _robotBossEnemySpawnerService = robotBossEnemySpawnerService ??
                                                throw new ArgumentNullException(nameof(robotBossEnemySpawnerService));
            _walkingEnemySpawnerService = walkingEnemySpawnerService ??
                                              throw new ArgumentNullException(nameof(walkingEnemySpawnerService));
            _standingTankEnemySpawnerService = standingTankEnemySpawnerService ??
                                               throw new ArgumentNullException(nameof(standingTankEnemySpawnerService));
            _boatBossEnemySpawnerService = boatBossEnemySpawnerService ??
                                           throw new ArgumentNullException(nameof(boatBossEnemySpawnerService));
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
                _helicopterEnemySpawnerService,
                _jeepEnemySpawnerService,
                _robotBossEnemySpawnerService,
                _dronEnemySpawnerService,
                _walkingEnemySpawnerService,
                _standingTankEnemySpawnerService,
                _boatBossEnemySpawnerService);
        }
    }
}