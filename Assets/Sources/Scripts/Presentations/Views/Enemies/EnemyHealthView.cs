using Sources.Scripts.Controllers.Presenters.Enemies;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Scripts.Presentations.Views.Enemies
{
    public class EnemyHealthView : PresentableView<EnemyHealthPresenter>, IEnemyHealthView
    {
        public Vector3 Position => transform.position;

        public float CurrentHealth => Presenter.CurrentHealth;

        public void TakeDamage(float damage) =>
            Presenter.TakeDamage(damage);
    }
}