using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopters;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Helicopter
{
    public class HelicopterAttackState : FiniteState
    {
        private readonly Enemy _enemy;
        private readonly IBazookaHelicopterEnemyView _enemyView;
        private readonly IEnemyAnimation _enemyAnimation;
        
        private TimeSpan _attackDelay = TimeSpan.FromSeconds(EnemyConst.AttackDelay);
        private CancellationTokenSource _cancellationTokenSource;
        private int _targetPositionIndex;

        public HelicopterAttackState(
            Enemy enemy,
            IBazookaHelicopterEnemyView enemyView,
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
        
        public override void Update(float deltaTime)
        {
            Vector3 currentTarget = _enemyView.MovementPoints[_targetPositionIndex].position;
            _enemyView.MoveToPoint(currentTarget);
            ChangeRotation();
            _enemyView.RotateRotor();
            
            if (Vector3.Distance(_enemyView.Position, currentTarget) < 0.1f)
                ChangeCurrentTargetPoint();
        }

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