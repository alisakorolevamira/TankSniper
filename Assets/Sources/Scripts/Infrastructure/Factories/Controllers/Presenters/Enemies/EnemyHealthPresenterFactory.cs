using Sources.Scripts.Controllers.Presenters.Enemies;
using Sources.Scripts.Domain.Models.Enemies;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies
{
    public class EnemyHealthPresenterFactory
    {
        public EnemyHealthPresenter Create(EnemyHealth enemyHealth, IEnemyHealthView view) =>
            new (enemyHealth, view);
    }
}