using System;
using Sources.Scripts.Controllers.Presenters.Enemies;
using Sources.Scripts.Domain.Models.Enemies;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies;
using Sources.Scripts.Presentations.Views.Enemies;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies;

namespace Sources.Scripts.Infrastructure.Factories.Views.Enemies
{
    public class EnemyHealthViewFactory
    {
        private readonly EnemyHealthPresenterFactory _presenterFactory;

        public EnemyHealthViewFactory(EnemyHealthPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IEnemyHealthView Create(EnemyHealth enemyHealth, EnemyHealthView view)
        {
            EnemyHealthPresenter presenter =
                _presenterFactory.Create(enemyHealth);

            view.Construct(presenter);

            return view;
        }
    }
}