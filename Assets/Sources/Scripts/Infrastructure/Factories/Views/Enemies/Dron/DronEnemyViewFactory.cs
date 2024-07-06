using System;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Domain.Models.Enemies.Dron;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Dron;
using Sources.Scripts.Infrastructure.Factories.Views.Common;
using Sources.Scripts.Presentations.Views.Enemies.Dron;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Dron;

namespace Sources.Scripts.Infrastructure.Factories.Views.Enemies.Dron
{
    public class DronEnemyViewFactory
    {
        private readonly DronEnemyPresenterFactory _presenterFactory;
        private readonly EnemyHealthViewFactory _enemyHealthViewFactory;
        private readonly HealthUITextViewFactory _healthUITextViewFactory;

        public DronEnemyViewFactory(
            DronEnemyPresenterFactory presenterFactory,
            EnemyHealthViewFactory enemyHealthViewFactory,
            HealthUITextViewFactory healthUITextViewFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
            _enemyHealthViewFactory = enemyHealthViewFactory ??
                                      throw new ArgumentNullException(nameof(enemyHealthViewFactory));
            _healthUITextViewFactory = healthUITextViewFactory ??
                                       throw new ArgumentNullException(nameof(healthUITextViewFactory));
        }

        public IDronEnemyView Create(DronEnemy dronEnemy, KilledEnemiesCounter killedEnemiesCounter, DronEnemyView view)
        {
            EnemyPresenter presenter = _presenterFactory.Create(
                dronEnemy, killedEnemiesCounter, view, view.EnemyAnimation);
            
            view.Construct(presenter);
            _enemyHealthViewFactory.Create(dronEnemy.EnemyHealth, view.EnemyHealthView);
            _healthUITextViewFactory.Create(dronEnemy.EnemyHealth, view.HealthUIText);
            
            return view;
        }
    }
}