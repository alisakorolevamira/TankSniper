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

        public ITankEnemyView Create(Enemy enemy, KilledEnemiesCounter killedEnemiesCounter, IEnemySpawnPoint spawnPoint)
        {
            TankTankEnemyView tankTankEnemyView = CreateView(spawnPoint);

            return Create(enemy, killedEnemiesCounter, tankTankEnemyView, spawnPoint);
        }

        public ITankEnemyView Create(Enemy enemy, KilledEnemiesCounter killedEnemiesCounter, TankTankEnemyView tankTankEnemyView, IEnemySpawnPoint spawnPoint)
        {
            EnemyPresenter enemyPresenter = _enemyPresenterFactory.Create(
                enemy, killedEnemiesCounter, tankTankEnemyView, tankTankEnemyView.EnemyAnimation, spawnPoint);

            tankTankEnemyView.Construct(enemyPresenter);

            _enemyHealthViewFactory.Create(enemy.EnemyHealth, tankTankEnemyView.EnemyHealthView);
            _healthBarUIFactory.Create(enemy.EnemyHealth, tankTankEnemyView.HealthBarUI);
            _healthUITextViewFactory.Create(enemy.EnemyHealth, tankTankEnemyView.HealthUIText);

            return tankTankEnemyView;
        }

        private TankTankEnemyView CreateView(IEnemySpawnPoint spawnPoint)
        {
            TankTankEnemyView tankTankEnemyView = spawnPoint.TankTankEnemyView;

            return tankTankEnemyView;
        }
    }
}