using System;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Infrastructure.Factories.Views.Common;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Scripts.Infrastructure.Factories.Views.Enemies.Base
{
    public class EnemyViewFactory : IEnemyViewFactory
    {
        private readonly EnemyPresenterFactory _enemyPresenterFactory;
        private readonly EnemyHealthViewFactory _enemyHealthViewFactory;
        private readonly HealthBarUIFactory _healthBarUIFactory;
        private readonly HealthUITextViewFactory _healthUITextViewFactory;

        public EnemyViewFactory(
            EnemyPresenterFactory enemyPresenterFactory,
            EnemyHealthViewFactory enemyHealthViewFactory,
            HealthBarUIFactory healthBarUIFactory,
            HealthUITextViewFactory healthUITextViewFactory)
        {
            _enemyPresenterFactory = enemyPresenterFactory ??
                                     throw new ArgumentNullException(nameof(enemyPresenterFactory));
            _enemyHealthViewFactory = enemyHealthViewFactory ??
                                      throw new ArgumentNullException(nameof(enemyHealthViewFactory));
            _healthBarUIFactory = healthBarUIFactory ?? throw new ArgumentNullException(nameof(healthBarUIFactory));
            _healthUITextViewFactory = healthUITextViewFactory ??
                                       throw new ArgumentNullException(nameof(healthUITextViewFactory));
        }

        public IEnemyView Create(Enemy enemy, KilledEnemiesCounter killedEnemiesCounter, IEnemySpawnPoint spawnPoint)
        {
            EnemyView enemyView = CreateView(spawnPoint);

            return Create(enemy, killedEnemiesCounter, enemyView, spawnPoint);
        }

        public IEnemyView Create(Enemy enemy, KilledEnemiesCounter killedEnemiesCounter, EnemyView enemyView, IEnemySpawnPoint spawnPoint)
        {
            EnemyPresenter enemyPresenter = _enemyPresenterFactory.Create(
                enemy, killedEnemiesCounter, enemyView, enemyView.EnemyAnimation, spawnPoint);

            enemyView.Construct(enemyPresenter);

            _enemyHealthViewFactory.Create(enemy.EnemyHealth, enemyView.EnemyHealthView);
            _healthBarUIFactory.Create(enemy.EnemyHealth, enemyView.HealthBarUI);
            _healthUITextViewFactory.Create(enemy.EnemyHealth, enemyView.HealthUIText);

            return enemyView;
        }

        private EnemyView CreateView(IEnemySpawnPoint spawnPoint)
        {
            EnemyView enemyView = spawnPoint.EnemyView;

            return enemyView;
        }
    }
}