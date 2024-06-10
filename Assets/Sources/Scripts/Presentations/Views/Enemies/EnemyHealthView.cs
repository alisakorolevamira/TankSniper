using Sources.Scripts.Controllers.Presenters.Enemies;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies
{
    public class EnemyHealthView : PresentableView<EnemyHealthPresenter>, IEnemyHealthView
    {
        [SerializeField] private ParticleSystem _bloodParticle;

        public Vector3 Position => transform.position;

        public float CurrentHealth => Presenter.CurrentHealth;

        public void TakeDamage(float damage) =>
            Presenter.TakeDamage(damage);

        public void PlayBloodParticle() =>
            _bloodParticle.Play();
    }
}