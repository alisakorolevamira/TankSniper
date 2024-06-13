using System;
using System.Linq;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Tank.States
{
    public class TankMovementState : FiniteState
    {
        private readonly ITankEnemyAnimation _enemyAnimation;
        private readonly ITankEnemyView _enemyView;
        private readonly IEnemySpawnPoint _spawnPoint;

        private Vector3 _currentTargetPoint;

        public TankMovementState(
            ITankEnemyAnimation enemyAnimation,
            ITankEnemyView enemyView,
            IEnemySpawnPoint spawnPoint)
        {
            _enemyAnimation = enemyAnimation;
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _spawnPoint = spawnPoint ?? throw new ArgumentNullException(nameof(spawnPoint));
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
            
            if(Vector3.Distance(_enemyView.Position, _currentTargetPoint) < 0.1f)
                ChangeCurrentTargetPoint();
        }

        private void ChangeCurrentTargetPoint()
        {
            _currentTargetPoint = _spawnPoint.Points.
                First(x => Vector3.Distance(_enemyView.Position, x.position) > 3).position;
        }
    }
}