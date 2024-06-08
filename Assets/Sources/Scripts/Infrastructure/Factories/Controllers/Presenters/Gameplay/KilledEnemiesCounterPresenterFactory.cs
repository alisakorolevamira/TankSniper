using Sources.Scripts.Controllers.Presenters.Gameplay;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.DomainInterfaces.Models.Spawners;
using Sources.Scripts.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Gameplay
{
    public class KilledEnemiesCounterPresenterFactory
    {
        public KilledEnemiesCounterPresenter Create(
            KilledEnemiesCounter killEnemyCounter,
            IEnemySpawner enemySpawner,
            IKilledEnemiesCounterView killEnemyCounterView)
        {
            return new KilledEnemiesCounterPresenter(killEnemyCounter, enemySpawner, killEnemyCounterView);
        }
    }
}