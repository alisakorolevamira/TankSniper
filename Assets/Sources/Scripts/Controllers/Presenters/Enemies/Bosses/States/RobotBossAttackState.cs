﻿using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Bosses;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Bosses.States
{
    public class RobotBossAttackState : FiniteState
    {
        private readonly Enemy _enemy;
        private readonly IRobotBossEnemyView _enemyView;
        private readonly IEnemyAnimation _enemyAnimation;
        
        private TimeSpan _attackDelay = TimeSpan.FromSeconds(EnemyConst.BossAttackDelay);
        private TimeSpan _attackTime = TimeSpan.FromSeconds(EnemyConst.BossAttackTime);
        private CancellationTokenSource _cancellationTokenSource;
        private int _targetPositionIndex;
        private bool _isAttacking;

        public RobotBossAttackState(Enemy enemy, IRobotBossEnemyView enemyView, IEnemyAnimation enemyAnimation)
        {
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _enemyAnimation = enemyAnimation ?? throw new ArgumentNullException(nameof(enemyAnimation));
        }

        public override void Enter()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            
            _enemyAnimation.PlayIdle();
            SetTimer(_cancellationTokenSource.Token);
        }

        public override void Exit() => 
            _cancellationTokenSource.Cancel();
        
        public override void Update(float deltaTime)
        {
            if (_isAttacking)
                return;
            
            Vector3 currentTarget = _enemyView.MovementPoints[_targetPositionIndex].position;
            
            _enemyView.MoveToPoint(currentTarget);
            ChangeRotation();
            
            if (Vector3.Distance(_enemyView.Position, currentTarget) < EnemyConst.MinDistance)
                ChangeCurrentTargetPoint();
        }

        private async void SetTimer(CancellationToken cancellationToken)
        {
            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    await UniTask.Delay(_attackDelay, cancellationToken: cancellationToken);

                    _isAttacking = true;
                    Attack();
                    
                    await UniTask.Delay(_attackTime, cancellationToken: cancellationToken);

                    _isAttacking = false;
                    _enemyAnimation.PlayIdle();
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void Attack()
        {
            _enemyView.SetLookAtPlayer();
            _enemyAnimation.PlayAttack();
            _enemyView.PlayerHealthView.TakeDamage(_enemy.EnemyAttacker.Damage);
        }
        
        private void ChangeCurrentTargetPoint()
        {
            _targetPositionIndex++;

            if (_targetPositionIndex >= _enemyView.MovementPoints.Count)
                _targetPositionIndex = 0;
        }

        private void ChangeRotation()
        {
            Vector3 direction = _enemyView.MovementPoints[_targetPositionIndex].position - _enemyView.Position;
            float targetAngle = Vector3.SignedAngle(Vector3.forward, direction, Vector3.up);
            
            _enemyView.SetRotation(targetAngle);
        }
    }
}