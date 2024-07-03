using System;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Domain.Models.Enemies.Jeep;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Jeep;
using Sources.Scripts.Infrastructure.Factories.Views.Common;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.Scripts.Presentations.Views.Enemies.Jeep;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Jeep;

namespace Sources.Scripts.Infrastructure.Factories.Views.Enemies.Jeep
{
    public class JeepEnemyViewFactory : IJeepEnemyViewFactory
    {
        private readonly JeepEnemyPresenterFactory _presenterFactory;
        private readonly EnemyHealthViewFactory _enemyHealthViewFactory;
        private readonly HealthUITextViewFactory _healthUITextViewFactory;

        public JeepEnemyViewFactory(
            JeepEnemyPresenterFactory presenterFactory,
            EnemyHealthViewFactory enemyHealthViewFactory,
            HealthUITextViewFactory healthUITextViewFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
            _enemyHealthViewFactory = enemyHealthViewFactory ??
                                      throw new ArgumentNullException(nameof(enemyHealthViewFactory));
            _healthUITextViewFactory = healthUITextViewFactory ??
                                       throw new ArgumentNullException(nameof(healthUITextViewFactory));
        }
        
        public IJeepEnemyView Create(JeepEnemy tankEnemy, KilledEnemiesCounter killedEnemiesCounter, JeepEnemyView view)
        {
            EnemyPresenter presenter = _presenterFactory.Create(
                tankEnemy, killedEnemiesCounter, view, view.EnemyAnimation);
            
            view.Construct(presenter);
            
            _enemyHealthViewFactory.Create(tankEnemy.EnemyHealth, view.EnemyHealthView);
            _healthUITextViewFactory.Create(tankEnemy.EnemyHealth, view.HealthUIText);

            return view;
        }
    }
}