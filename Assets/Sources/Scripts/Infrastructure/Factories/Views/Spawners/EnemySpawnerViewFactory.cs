using System;
using Sources.Scripts.Controllers.Presenters.Spawners;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Spawners;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Spawners;
using Sources.Scripts.Presentations.Views.Spawners;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;

namespace Sources.Scripts.Infrastructure.Factories.Views.Spawners
{
    public class EnemySpawnerViewFactory
    {
        private readonly EnemySpawnerPresenterFactory _enemySpawnerPresenterFactory;

        public EnemySpawnerViewFactory(EnemySpawnerPresenterFactory enemySpawnerPresenterFactory)
        {
            _enemySpawnerPresenterFactory = enemySpawnerPresenterFactory ??
                                          throw new ArgumentNullException(nameof(enemySpawnerPresenterFactory));
        }

        public IEnemySpawnerView Create(
            EnemySpawner enemySpawner,
            KilledEnemiesCounter killedEnemiesCounter,
            EnemySpawnerView enemySpawnerView)
        {
            EnemySpawnerPresenter enemySpawnerPresenter =
                _enemySpawnerPresenterFactory.Create(enemySpawner, killedEnemiesCounter, enemySpawnerView);

            enemySpawnerView.Construct(enemySpawnerPresenter);

            return enemySpawnerView;
        }
    }
}