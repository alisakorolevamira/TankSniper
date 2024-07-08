using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies.Boss;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Bosses;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Bosses.States
{
    public class BoatBossAttackState : FiniteState
    {
        private readonly BossEnemy _enemy;
        private readonly IBoatBossEnemyView _enemyView;
        private readonly IEnemyAnimation _enemyAnimation;
        
        private CancellationTokenSource _cancellationTokenSource;
        private TimeSpan _attackDelay = TimeSpan.FromSeconds(EnemyConst.AttackDelay);

        public BoatBossAttackState(
            BossEnemy enemy,
            IBoatBossEnemyView enemyView,
            IEnemyAnimation enemyAnimation)
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