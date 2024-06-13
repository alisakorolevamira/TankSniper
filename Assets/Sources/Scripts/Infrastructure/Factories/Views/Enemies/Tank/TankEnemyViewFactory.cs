using System;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies.Tank;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Tank;
using Sources.Scripts.Infrastructure.Factories.Views.Common;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.Scripts.Presentations.Views.Enemies.Tank;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Scripts.Infrastructure.Factories.Views.Enemies.Tank
{
    public class TankEnemyViewFactory : ITankEnemyViewFactory
    {
        private readonly TankPresenterFactory _tankPresenterFactory;
        private readonly EnemyHealthViewFactory _enemyHealthViewFactory;
        private readonly HealthBarUIFactory _healthBarUIFactory;
        private readonly HealthUITextViewFactory _healthUITextViewFactory;

        public TankEnemyViewFactory(
            TankPresenterFactory tankPresenterFactory,
            EnemyHealthViewFactory enemyHealthViewFactory,
            HealthBarUIFactory healthBarUIFactory,
            HealthUITextViewFactory healthUITextViewFactory)
        {
            _tankPresenterFactory = tankPresenterFactory ??
                                    throw new ArgumentNullException(nameof(tankPresenterFactory));
            _enemyHealthViewFactory = enemyHealthViewFactory ??
                                      throw new ArgumentNullException(nameof(enemyHealthViewFactory));
            _healthBarUIFactory = healthBarUIFactory ?? throw new ArgumentNullException(nameof(healthBarUIFactory));
            _healthUITextViewFactory = healthUITextViewFactory ??
                                       throw new ArgumentNullException(nameof(healthUITextViewFactory));
        }

        public ITankEnemyView Create(TankEnemy tankEnemy, KilledEnemiesCounter killedEnemiesCounter, IEnemySpawnPoint spawnPoint)
        {
            TankEnemyView view = Object.Instantiate(
                Resources.Load<TankEnemyView>(PrefabPath.TankEnemy));

            EnemyPresenter presenter = _tankPresenterFactory.Create(
                tankEnemy, killedEnemiesCounter, view, view.EnemyAnimation, spawnPoint);
            
            view.Construct(presenter);
            
            _enemyHealthViewFactory.Create(tankEnemy.EnemyHealth, view.EnemyHealthView);
            _healthBarUIFactory.Create(tankEnemy.EnemyHealth, view.HealthBarUI);
            _healthUITextViewFactory.Create(tankEnemy.EnemyHealth, view.HealthUIText);

            return view;
        }
    }
}