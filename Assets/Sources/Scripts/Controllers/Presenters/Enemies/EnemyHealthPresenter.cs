using System;
using Sources.Scripts.Domain.Models.Enemies;

namespace Sources.Scripts.Controllers.Presenters.Enemies
{
    public class EnemyHealthPresenter : PresenterBase
    {
        private readonly EnemyHealth _enemyHealth;

        public EnemyHealthPresenter(EnemyHealth enemyHealth)
        {
            _enemyHealth = enemyHealth ?? throw new ArgumentNullException(nameof(enemyHealth));
        }

        public float CurrentHealth => _enemyHealth.CurrentHealth;

        public void TakeDamage(float damage) => 
            _enemyHealth.TakeDamage(damage);
    }
}