﻿using System;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Helicopters;
using Sources.Scripts.Infrastructure.Factories.Views.Common;
using Sources.Scripts.Presentations.Views.Enemies.Helicopters;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopters;

namespace Sources.Scripts.Infrastructure.Factories.Views.Enemies.Helicopters
{
    public class HelicopterEnemyViewFactory
    {
        private readonly HelicopterEnemyPresenterFactory _presenterFactory;
        private readonly EnemyHealthViewFactory _enemyHealthViewFactory;
        private readonly HealthUITextViewFactory _healthUITextViewFactory;

        public HelicopterEnemyViewFactory(
            HelicopterEnemyPresenterFactory presenterFactory,
            EnemyHealthViewFactory enemyHealthViewFactory,
            HealthUITextViewFactory healthUITextViewFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
            _enemyHealthViewFactory = enemyHealthViewFactory ??
                                      throw new ArgumentNullException(nameof(enemyHealthViewFactory));
            _healthUITextViewFactory = healthUITextViewFactory ??
                                       throw new ArgumentNullException(nameof(healthUITextViewFactory));
        }

        public IHelicopterEnemyView Create(
            Enemy enemy,
            KilledEnemiesCounter killedEnemiesCounter,
            HelicopterEnemyView view)
        {
            EnemyPresenter presenter = _presenterFactory.Create(enemy, killedEnemiesCounter, view, view.EnemyAnimation);
            
            view.Construct(presenter);
            
            _enemyHealthViewFactory.Create(enemy.EnemyHealth, view.EnemyHealthView);
            _healthUITextViewFactory.Create(enemy.EnemyHealth, view.HealthUIText);

            return view;
        }
    }
}