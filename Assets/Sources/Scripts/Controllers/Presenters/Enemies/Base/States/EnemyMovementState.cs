using System;
using System.Linq;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Base.States
{
    public class EnemyMovementState : FiniteState
    {
        private readonly IEnemyAnimation _enemyAnimation;
        private readonly ITankEnemyView tankEnemyView;
        private readonly IEnemySpawnPoint _spawnPoint;

        private Vector3 _currentTargetPoint;

        public EnemyMovementState(
            IEnemyAnimation enemyAnimation,
            ITankEnemyView tankEnemyView,
            IEnemySpawnPoint spawnPoint)
        {
            _enemyAnimation = enemyAnimation;
            this.tankEnemyView = tankEnemyView ?? throw new ArgumentNullException(nameof(tankEnemyView));
            _spawnPoint = spawnPoint ?? throw new ArgumentNullException(nameof(spawnPoint));
        }

        public override void Enter()
        {
            _enemyAnimation.PlayWalk();
            ChangeCurrentTargetPoint();
        }

        public override void Update(float deltaTime)
        {
            tankEnemyView.Move(_currentTargetPoint);
            
            if(Vector3.Distance(tankEnemyView.Position, _currentTargetPoint) < 0.1f)
                ChangeCurrentTargetPoint();
        }

        private void ChangeCurrentTargetPoint()
        {
            _currentTargetPoint = _spawnPoint.Points.
                First(x => Vector3.Distance(tankEnemyView.Position, x.position) > 3).position;
        }
    }
}