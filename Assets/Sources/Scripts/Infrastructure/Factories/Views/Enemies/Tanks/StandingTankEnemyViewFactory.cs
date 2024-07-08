using System;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Domain.Models.Enemies.Tanks;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Tanks;
using Sources.Scripts.Infrastructure.Factories.Views.Common;
using Sources.Scripts.Presentations.Views.Enemies.Tanks;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tanks;

namespace Sources.Scripts.Infrastructure.Factories.Views.Enemies.Tanks
{
    public class StandingTankEnemyViewFactory
    {
        private readonly StandingTankPresenterFactory _tankPresenterFactory;
        private readonly EnemyHealthViewFactory _enemyHealthViewFactory;
        private readonly HealthUITextViewFactory _healthUITextViewFactory;

        public StandingTankEnemyViewFactory(
            StandingTankPresenterFactory tankPresenterFactory,
            EnemyHealthViewFactory enemyHealthViewFactory,
            HealthUITextViewFactory healthUITextViewFactory)
        {
            _tankPresenterFactory = tankPresenterFactory ??
                                    throw new ArgumentNullException(nameof(tankPresenterFactory));
            _enemyHealthViewFactory = enemyHealthViewFactory ??
                                      throw new ArgumentNullException(nameof(enemyHealthViewFactory));
            _healthUITextViewFactory = healthUITextViewFactory ??
                                       throw new ArgumentNullException(nameof(healthUITextViewFactory));
        }

        public IStandingTankEnemyView Create(StandingTankEnemy tankEnemy, KilledEnemiesCounter killedEnemiesCounter, StandingTankEnemyView view)
        {
            EnemyPresenter presenter = _tankPresenterFactory.Create(
                tankEnemy, killedEnemiesCounter, view, view.EnemyAnimation);
            
            view.Construct(presenter);
            _enemyHealthViewFactory.Create(tankEnemy.EnemyHealth, view.EnemyHealthView);
            _healthUITextViewFactory.Create(tankEnemy.EnemyHealth, view.HealthUIText);

            return view;
        }
    }
}