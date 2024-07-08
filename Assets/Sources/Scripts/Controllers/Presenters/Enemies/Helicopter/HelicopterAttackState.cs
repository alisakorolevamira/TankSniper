using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies.Helicopter;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopter;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Helicopter
{
    public class HelicopterAttackState : FiniteState
    {
        private readonly HelicopterEnemy _enemy;
        private readonly IHelicopterEnemyView _enemyView;
        private readonly IHelicopterEnemyAnimation _enemyAnimation;
        
        private TimeSpan _attackDelay = TimeSpan.FromSeconds(EnemyConst.AttackDelay);
        private CancellationTokenSource _cancellationTokenSource;

        public HelicopterAttackState(
            HelicopterEnemy enemy,
            IHelicopterEnemyView enemyView,
            IHelicopterEnemyAnimation enemyAnimation)
        {
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _enemyAnimation = enemyAnimation ?? throw new ArgumentNullException(nameof(enemyAnimation));
        }

        public override void Enter()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            
            SetTimer(_cancellationTokenSource.Token);
        }

        public override void Exit() => 
            _cancellationTokenSource.Cancel();

        private async void SetTimer(CancellationToken cancellationToken)
        {
            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    await UniTask.Delay(_attackDelay, cancellationToken: cancellationToken);

                    Attack();
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void Attack()
        {
            _enemyView.PlayerHealthView.TakeDamage(_enemy.EnemyAttacker.Damage);
            _enemyAnimation.PlayAttack();
        }
    }
}