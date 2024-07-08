using System;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Boat;
using Sources.Scripts.Infrastructure.Factories.Views.Common;
using Sources.Scripts.Presentations.Views.Enemies.Boat;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boat;

namespace Sources.Scripts.Infrastructure.Factories.Views.Enemies.Boat
{
    public class BoatEnemyViewFactory
    {
        private readonly BoatEnemyPresenterFactory _presenterFactory;
        private readonly EnemyHealthViewFactory _enemyHealthViewFactory;
        private readonly HealthUITextViewFactory _healthUITextViewFactory;

        public BoatEnemyViewFactory(
            BoatEnemyPresenterFactory presenterFactory,
            EnemyHealthViewFactory enemyHealthViewFactory,
            HealthUITextViewFactory healthUITextViewFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
            _enemyHealthViewFactory = enemyHealthViewFactory ??
                                      throw new ArgumentNullException(nameof(enemyHealthViewFactory));
            _healthUITextViewFactory = healthUITextViewFactory ??
                                       throw new ArgumentNullException(nameof(healthUITextViewFactory));
        }

        public IBoatEnemyView Create(Enemy enemy, KilledEnemiesCounter killedEnemiesCounter, BoatEnemyView view)
        {
            EnemyPresenter presenter = _presenterFactory.Create(enemy, killedEnemiesCounter, view, view.EnemyAnimation);
            
            view.Construct(presenter);
            _enemyHealthViewFactory.Create(enemy.EnemyHealth, view.EnemyHealthView);
            _healthUITextViewFactory.Create(enemy.EnemyHealth, view.HealthUIText);
            
            return view;
        }
    }
}