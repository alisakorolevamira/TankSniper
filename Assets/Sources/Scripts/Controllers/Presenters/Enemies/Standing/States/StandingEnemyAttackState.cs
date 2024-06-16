﻿using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies.Standing;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Standing;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Standing.States
{
    public class StandingEnemyAttackState : FiniteState
    {
        private readonly StandingEnemy _enemy;
        private readonly IStandingEnemyView _enemyView;
        private readonly IStandingEnemyAnimation _enemyAnimation;
        
        private CancellationTokenSource _cancellationTokenSource;
        private TimeSpan _attackDelay;

        public StandingEnemyAttackState(
            StandingEnemy enemy,
            IStandingEnemyView enemyView,
            IStandingEnemyAnimation enemyAnimation)
        {
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _enemyAnimation = enemyAnimation ?? throw new ArgumentNullException(nameof(enemyAnimation));
        }

        public override void Enter()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _attackDelay = TimeSpan.FromSeconds(EnemyConst.AttackDelay);
            
            _enemyView.SetLookAtPlayer();
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