using System;
using Sources.Scripts.Controllers.Presenters.Spawners;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Spawners
{
    public class EnemySpawnerPresenterFactory
    {
        private readonly ITankEnemySpawnerService _tankEnemySpawnerService;
        private readonly IBossEnemySpawnerService _bossEnemySpawnerService;
        private readonly IStandingEnemySpawnerService _standingEnemySpawnerService;
        private readonly IHelicopterEnemySpawnerService _helicopterEnemySpawnerService;

        public EnemySpawnerPresenterFactory(
            ITankEnemySpawnerService tankEnemySpawnerService,
            IBossEnemySpawnerService bossEnemySpawnerService,
            IStandingEnemySpawnerService standingEnemySpawnerService,
            IHelicopterEnemySpawnerService helicopterEnemySpawnerService)
        {
            _tankEnemySpawnerService = tankEnemySpawnerService ?? throw new ArgumentNullException(nameof(tankEnemySpawnerService));
            _standingEnemySpawnerService = standingEnemySpawnerService ??
                                           throw new ArgumentNullException(nameof(standingEnemySpawnerService));
            _helicopterEnemySpawnerService = helicopterEnemySpawnerService ??
                                            throw new ArgumentNullException(nameof(helicopterEnemySpawnerService));
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
                _helicopterEnemySpawnerService,
                _bossEnemySpawnerService);
        }
    }
}