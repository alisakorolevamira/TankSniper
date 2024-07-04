using System;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Boss.States
{
    public class BossMovementState : FiniteState
    {
        private readonly IEnemyAnimation _enemyAnimation;
        private readonly IBossEnemyView _enemyView;
        
        private int _targetPositionIndex = 0;
        private Vector3 _targetPoint;

        public BossMovementState(IEnemyAnimation enemyAnimation, IBossEnemyView enemyView)
        {
            _enemyAnimation = enemyAnimation ?? throw new ArgumentNullException(nameof(enemyAnimation));
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
        }

        public override void Enter() => 
            _enemyAnimation.PlayIdle();

        public override void Update(float deltaTime)
        {
            Vector3 currentTarget = _enemyView.MovementPoints[_targetPositionIndex].position;
            _enemyView.MoveToPoint(currentTarget);
            ChangeRotation();
            
            if (Vector3.Distance(_enemyView.Position, currentTarget) < 0.1f)
                ChangeCurrentTargetPoint();
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