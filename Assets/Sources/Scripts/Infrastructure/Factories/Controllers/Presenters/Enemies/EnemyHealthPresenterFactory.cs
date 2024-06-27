using Sources.Scripts.Controllers.Presenters.Enemies;
using Sources.Scripts.Domain.Models.Enemies;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies
{
    public class EnemyHealthPresenterFactory
    {
        public EnemyHealthPresenter Create(EnemyHealth enemyHealth) =>
            new (enemyHealth);
    }
}