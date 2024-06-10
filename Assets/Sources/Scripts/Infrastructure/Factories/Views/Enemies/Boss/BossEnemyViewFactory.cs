using System;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies.Boss;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Boss;
using Sources.Scripts.Infrastructure.Factories.Views.Common;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.Scripts.InfrastructureInterfaces.Services.ObjectPool.Generic;
using Sources.Scripts.Presentations.Views.Enemies.Boss;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss;
using Sources.Scripts.PresentationsInterfaces.Views.ObjectPool;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Scripts.Infrastructure.Factories.Views.Enemies.Boss
{
    public class BossEnemyViewFactory : IBossEnemyViewFactory
    {
        private readonly BossEnemyPresenterFactory _bossEnemyPresenterFactory;
        //private readonly IObjectPool<BossEnemyView> _bossEnemyPool;
        private readonly EnemyHealthViewFactory _enemyHealthViewFactory;
        private readonly HealthBarUIFactory _healthBarUIFactory;
        private readonly HealthUITextViewFactory _healthUITextViewFactory;

        public BossEnemyViewFactory(
            BossEnemyPresenterFactory bossEnemyPresenterFactory,
            //IObjectPool<BossEnemyView> bossEnemyPool,
            EnemyHealthViewFactory enemyHealthViewFactory,
            HealthBarUIFactory healthBarUIFactory,
            HealthUITextViewFactory healthUITextViewFactory)
        {
            _bossEnemyPresenterFactory = bossEnemyPresenterFactory ??
                                         throw new ArgumentNullException(nameof(bossEnemyPresenterFactory));
            //_bossEnemyPool = bossEnemyPool ?? throw new ArgumentNullException(nameof(bossEnemyPool));
            _enemyHealthViewFactory = enemyHealthViewFactory ??
                                      throw new ArgumentNullException(nameof(enemyHealthViewFactory));
            _healthBarUIFactory = healthBarUIFactory ?? throw new ArgumentNullException(nameof(healthBarUIFactory));
            _healthUITextViewFactory = healthUITextViewFactory ??
                                       throw new ArgumentNullException(nameof(healthUITextViewFactory));
        }

        public IBossEnemyView Create(BossEnemy bossEnemy, KilledEnemiesCounter killedEnemiesCounter)
        {
            BossEnemyView bossEnemyView = CreateView();

            return Create(bossEnemy, killedEnemiesCounter, bossEnemyView);
        }

        public IBossEnemyView Create(
            BossEnemy bossEnemy,
            KilledEnemiesCounter killedEnemiesCounter,
            BossEnemyView bossEnemyView)
        {
            EnemyPresenter enemyPresenter = _bossEnemyPresenterFactory.Create(
                bossEnemy, killedEnemiesCounter, bossEnemyView, bossEnemyView.BossEnemyAnimation);

            bossEnemyView.Construct(enemyPresenter);

            _enemyHealthViewFactory.Create(bossEnemy.EnemyHealth, bossEnemyView.EnemyHealthView);
            _healthBarUIFactory.Create(bossEnemy.EnemyHealth, bossEnemyView.HealthBarUI);
            _healthUITextViewFactory.Create(bossEnemy.EnemyHealth, bossEnemyView.HealthUIText);

            return bossEnemyView;
        }

        private BossEnemyView CreateView()
        {
            BossEnemyView bossEnemyView = Object.Instantiate(Resources.Load<BossEnemyView>(PrefabPath.BossEnemy));

            //bossEnemyView.AddComponent<PoolableObject>().SetPool(_bossEnemyPool);

            return bossEnemyView;
        }
    }
}