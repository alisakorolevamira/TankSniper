using System;
using Sources.Scripts.Controllers.Presenters.Gameplay;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.DomainInterfaces.Models.Spawners;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Gameplay;
using Sources.Scripts.Presentations.Views.Gameplay;
using Sources.Scripts.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Scripts.Infrastructure.Factories.Views.Gameplay
{
    public class KilledEnemiesCounterViewFactory
    {
        private readonly KilledEnemiesCounterPresenterFactory _presenterFactory;

        public KilledEnemiesCounterViewFactory(KilledEnemiesCounterPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IKilledEnemiesCounterView Create(
            KilledEnemiesCounter killedEnemiesCounter,
            IEnemySpawner enemySpawner,
            KilledEnemiesCounterView killedEnemiesCounterView)
        {
            KilledEnemiesCounterPresenter presenter =
                _presenterFactory.Create(killedEnemiesCounter, enemySpawner, killedEnemiesCounterView);
            
            killedEnemiesCounterView.Construct(presenter);
            
            return killedEnemiesCounterView;
        }
    }
}