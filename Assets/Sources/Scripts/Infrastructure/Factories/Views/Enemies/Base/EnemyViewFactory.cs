using System;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Infrastructure.Factories.Views.Common;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.Scripts.InfrastructureInterfaces.Services.ObjectPool.Generic;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.ObjectPool;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Scripts.Infrastructure.Factories.Views.Enemies.Base
{
    public class EnemyViewFactory : IEnemyViewFactory
    {
        private readonly EnemyPresenterFactory _enemyPresenterFactory;
        //private readonly IObjectPool<EnemyView> _enemyPool;
        private readonly EnemyHealthViewFactory _enemyHealthViewFactory;
        private readonly HealthBarUIFactory _healthBarUIFactory;
        private readonly HealthUITextViewFactory _healthUITextViewFactory;

        public EnemyViewFactory(
            EnemyPresenterFactory enemyPresenterFactory,
            //IObjectPool<EnemyView> enemyPool,
            EnemyHealthViewFactory enemyHealthViewFactory,
            HealthBarUIFactory healthBarUIFactory,
            HealthUITextViewFactory healthUITextViewFactory)
        {
            _enemyPresenterFactory = enemyPresenterFactory ??
                                     throw new ArgumentNullException(nameof(enemyPresenterFactory));
            //_enemyPool = enemyPool ?? throw new ArgumentNullException(nameof(enemyPool));
            _enemyHealthViewFactory = enemyHealthViewFactory ??
                                      throw new ArgumentNullException(nameof(enemyHealthViewFactory));
            _healthBarUIFactory = healthBarUIFactory ?? throw new ArgumentNullException(nameof(healthBarUIFactory));
            _healthUITextViewFactory = healthUITextViewFactory ??
                                       throw new ArgumentNullException(nameof(healthUITextViewFactory));
        }

        public IEnemyView Create(Enemy enemy, KilledEnemiesCounter killedEnemiesCounter)
        {
            EnemyView enemyView = CreateView();

            return Create(enemy, killedEnemiesCounter, enemyView);
        }

        public IEnemyView Create(Enemy enemy, KilledEnemiesCounter killedEnemiesCounter, EnemyView enemyView)
        {
            EnemyPresenter enemyPresenter = _enemyPresenterFactory.Create(
                enemy, killedEnemiesCounter, enemyView, enemyView.EnemyAnimation);

            enemyView.Construct(enemyPresenter);

            _enemyHealthViewFactory.Create(enemy.EnemyHealth, enemyView.EnemyHealthView);
            _healthBarUIFactory.Create(enemy.EnemyHealth, enemyView.HealthBarUI);
            _healthUITextViewFactory.Create(enemy.EnemyHealth, enemyView.HealthUIText);

            return enemyView;
        }

        private EnemyView CreateView()
        {
            EnemyView enemyView = Object.Instantiate(Resources.Load<EnemyView>(PrefabPath.Enemy));

           // enemyView.AddComponent<PoolableObject>().SetPool(_enemyPool);

            return enemyView;
        }
    }
}