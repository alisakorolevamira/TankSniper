using Sources.Scripts.Controllers.Presenters.Enemies;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies;

namespace Sources.Scripts.Presentations.Views.Enemies
{
    public class EnemyHealthView : PresentableView<EnemyHealthPresenter>, IEnemyHealthView
    {
        public float CurrentHealth => Presenter.CurrentHealth;

        public void TakeDamage(float damage) =>
            Presenter?.TakeDamage(damage);
    }
}