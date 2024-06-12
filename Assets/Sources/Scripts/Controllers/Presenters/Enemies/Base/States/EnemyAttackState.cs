using System;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Base.States
{
    public class EnemyAttackState : FiniteState
    {
        private readonly Enemy _enemy;
        private readonly IEnemyView _enemyView;
        private readonly IEnemyAnimation _enemyAnimation;

        public EnemyAttackState(
            Enemy enemy,
            IEnemyView enemyView,
            IEnemyAnimation enemyAnimation)
        {
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _enemyAnimation = enemyAnimation ?? throw new ArgumentNullException(nameof(enemyAnimation));
        }

        public override void Enter()
        {
            _enemyAnimation.PlayAttack();
            _enemyAnimation.Attacking += OnAttack;
        }

        public override void Exit() =>
            _enemyAnimation.Attacking -= OnAttack;

        private void OnAttack() =>
            _enemyView.PlayerView.PlayerHealthView.TakeDamage(_enemy.EnemyAttacker.Damage);
    }
}