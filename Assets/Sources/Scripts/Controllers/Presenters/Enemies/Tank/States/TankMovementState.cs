using System;
using System.Linq;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Tank.States
{
    public class TankMovementState : FiniteState
    {
        private readonly IEnemyAnimation _enemyAnimation;
        private readonly ITankEnemyView _enemyView;

        private Vector3 _currentTargetPoint;

        public TankMovementState(IEnemyAnimation enemyAnimation, ITankEnemyView enemyView)
        {
            _enemyAnimation = enemyAnimation ?? throw new ArgumentNullException(nameof(enemyAnimation));
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
        }

        public override void Enter()
        {
            _enemyAnimation.PlayIdle();
            ChangeCurrentTargetPoint();
        }

        public override void Exit() => 
            _enemyView.Stop();

        public override void Update(float deltaTime)
        {
            _enemyView.Move(_currentTargetPoint);
            
            if (Vector3.Distance(_enemyView.Position, _currentTargetPoint) < 0.1f)
                ChangeCurrentTargetPoint();
        }

        private void ChangeCurrentTargetPoint()
        {
            _currentTargetPoint = _enemyView.MovementPoints.
                First(x => Vector3.Distance(_enemyView.Position, x.position) > 3).position;
        }
    }
}