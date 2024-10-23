using System;
using Sources.Scripts.Controllers.Presenters.Spawners;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Boat;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Bosses;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Dron;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Helicopters;
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
        private readonly IBazookaHelicopterEnemySpawnerService _bazookaEnemySpawnerService;
        private readonly IDronEnemySpawnerService _dronEnemySpawnerService;
        private readonly IWalkingEnemySpawnerService _walkingEnemySpawnerService;
        private readonly IBoatEnemySpawnerService _boatEnemySpawnerService;
        private readonly IStandingTankEnemySpawnerService _standingTankEnemySpawnerService;
        private readonly IHelicopterEnemySpawnerService _helicopterEnemySpawnerService;
        private readonly IBoatBossEnemySpawnerService _boatBossEnemySpawnerService;
        private readonly IHelicopterBossEnemySpawnerService _helicopterBossEnemySpawnerService;

        public EnemySpawnerPresenterFactory(
            ITankEnemySpawnerService tankEnemySpawnerService,
            IRobotBossEnemySpawnerService robotBossEnemySpawnerService,
            IStandingEnemySpawnerService standingEnemySpawnerService,
            IJeepEnemySpawnerService jeepEnemySpawnerService,
            IBazookaHelicopterEnemySpawnerService bazookaEnemySpawnerService,
            IDronEnemySpawnerService dronEnemySpawnerService,
            IWalkingEnemySpawnerService walkingEnemySpawnerService,
            IBoatEnemySpawnerService boatEnemySpawnerService,
            IStandingTankEnemySpawnerService standingTankEnemySpawnerService,
            IHelicopterEnemySpawnerService helicopterEnemySpawnerService,
            IBoatBossEnemySpawnerService boatBossEnemySpawnerService,
            IHelicopterBossEnemySpawnerService helicopterBossEnemySpawnerService)
        {
            _tankEnemySpawnerService = tankEnemySpawnerService ??
                                       throw new ArgumentNullException(nameof(tankEnemySpawnerService));
            _standingEnemySpawnerService = standingEnemySpawnerService ??
                                           throw new ArgumentNullException(nameof(standingEnemySpawnerService));
            _jeepEnemySpawnerService = jeepEnemySpawnerService ??
                                       throw new ArgumentNullException(nameof(jeepEnemySpawnerService));
            _bazookaEnemySpawnerService = bazookaEnemySpawnerService ??
                                          throw new ArgumentNullException(nameof(bazookaEnemySpawnerService));
            _dronEnemySpawnerService = dronEnemySpawnerService ??
                                       throw new ArgumentNullException(nameof(dronEnemySpawnerService));
            _robotBossEnemySpawnerService = robotBossEnemySpawnerService ??
                                                throw new ArgumentNullException(nameof(robotBossEnemySpawnerService));
            _walkingEnemySpawnerService = walkingEnemySpawnerService ??
                                              throw new ArgumentNullException(nameof(walkingEnemySpawnerService));
            _boatEnemySpawnerService = boatEnemySpawnerService ??
                                       throw new ArgumentNullException(nameof(boatEnemySpawnerService));
            _standingTankEnemySpawnerService = standingTankEnemySpawnerService ??
                                               throw new ArgumentNullException(nameof(standingTankEnemySpawnerService));
            _helicopterEnemySpawnerService = helicopterEnemySpawnerService ??
                                             throw new ArgumentNullException(nameof(helicopterEnemySpawnerService));
            _boatBossEnemySpawnerService = boatBossEnemySpawnerService ??
                                           throw new ArgumentNullException(nameof(boatBossEnemySpawnerService));
            _helicopterBossEnemySpawnerService = helicopterBossEnemySpawnerService ??
                                                 throw new ArgumentNullException(nameof(helicopterBossEnemySpawnerService));
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
                _bazookaEnemySpawnerService,
                _jeepEnemySpawnerService,
                _robotBossEnemySpawnerService,
                _dronEnemySpawnerService,
                _walkingEnemySpawnerService,
                _boatEnemySpawnerService,
                _helicopterEnemySpawnerService,
                _standingTankEnemySpawnerService,
                _boatBossEnemySpawnerService,
                _helicopterBossEnemySpawnerService);
        }
    }
}