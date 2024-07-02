﻿using System;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Domain.Models.Enemies.Standing;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Standing;
using Sources.Scripts.Infrastructure.Factories.Views.Common;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.Presentations.Views.Enemies.Standing;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Standing;

namespace Sources.Scripts.Infrastructure.Factories.Views.Enemies.Standing
{
    public class StandingEnemyViewFactory : IStandingEnemyViewFactory
    {
        private readonly StandingEnemyPresenterFactory _presenterFactory;
        private readonly EnemyHealthViewFactory _enemyHealthViewFactory;
        private readonly HealthUITextViewFactory _healthUITextViewFactory;

        public StandingEnemyViewFactory(
            StandingEnemyPresenterFactory presenterFactory,
            EnemyHealthViewFactory enemyHealthViewFactory,
            HealthUITextViewFactory healthUITextViewFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
            _enemyHealthViewFactory = enemyHealthViewFactory ??
                                      throw new ArgumentNullException(nameof(enemyHealthViewFactory));
            _healthUITextViewFactory = healthUITextViewFactory ??
                                       throw new ArgumentNullException(nameof(healthUITextViewFactory));
        }

        public IStandingEnemyView Create(StandingEnemy enemy, KilledEnemiesCounter killedEnemiesCounter, EnemyViewBase enemyViewBase)
        {
           StandingEnemyView view = enemyViewBase as StandingEnemyView;

            EnemyPresenter presenter = _presenterFactory.Create(
                enemy, killedEnemiesCounter, view, view.EnemyAnimation);
            
            view.Construct(presenter);
            
            _enemyHealthViewFactory.Create(enemy.EnemyHealth, view.EnemyHealthView);
            _healthUITextViewFactory.Create(enemy.EnemyHealth, view.HealthUIText);

            return view;
        }
    }
}