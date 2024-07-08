﻿using System;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Domain.Models.Enemies.Boss;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Bosses;
using Sources.Scripts.Infrastructure.Factories.Views.Common;
using Sources.Scripts.Presentations.Views.Enemies.Bosses;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Bosses;

namespace Sources.Scripts.Infrastructure.Factories.Views.Enemies.Bosses
{
    public class BoatBossEnemyViewFactory
    {
        private readonly BoatBossEnemyPresenterFactory _presenterFactory;
        private readonly EnemyHealthViewFactory _enemyHealthViewFactory;
        private readonly HealthUITextViewFactory _healthUITextViewFactory;
        private readonly HealthBarUIFactory _healthBarUIFactory;

        public BoatBossEnemyViewFactory(
            BoatBossEnemyPresenterFactory presenterFactory,
            EnemyHealthViewFactory enemyHealthViewFactory,
            HealthUITextViewFactory healthUITextViewFactory,
            HealthBarUIFactory healthBarUIFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
            _enemyHealthViewFactory = enemyHealthViewFactory ??
                                      throw new ArgumentNullException(nameof(enemyHealthViewFactory));
            _healthUITextViewFactory = healthUITextViewFactory ??
                                       throw new ArgumentNullException(nameof(healthUITextViewFactory));
            _healthBarUIFactory = healthBarUIFactory ?? throw new ArgumentNullException(nameof(healthBarUIFactory));
        }

        public IBoatBossEnemyView Create(
            BossEnemy bossEnemy,
            KilledEnemiesCounter killedEnemiesCounter,
            BoatBossEnemyView view)
        {
            EnemyPresenter presenter = _presenterFactory.Create(
                bossEnemy, killedEnemiesCounter, view, view.EnemyAnimation);
            
            view.Construct(presenter);
            _enemyHealthViewFactory.Create(bossEnemy.EnemyHealth, view.EnemyHealthView);
            _healthUITextViewFactory.Create(bossEnemy.EnemyHealth, view.HealthUIText);
            _healthBarUIFactory.Create(bossEnemy.EnemyHealth, view.HealthBar);
            
            return view;
        }
    }
}