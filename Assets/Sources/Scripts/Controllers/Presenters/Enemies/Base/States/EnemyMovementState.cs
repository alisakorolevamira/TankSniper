using System;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Base.States
{
    public class EnemyMovementState : FiniteState
    {
        private readonly IEnemyAnimation _enemyAnimation;
        private readonly IEnemyView _enemyView;
        private readonly IEnemySpawnPoint _spawnPoint;

        public EnemyMovementState(
            IEnemyAnimation enemyAnimation,
            IEnemyView enemyView,
            IEnemySpawnPoint spawnPoint)
        {
            _enemyAnimation = enemyAnimation;
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _spawnPoint = spawnPoint ?? throw new ArgumentNullException(nameof(spawnPoint));
        }

        public override void Enter()
        {
            _enemyAnimation.PlayWalk();
            _enemyView.Move(_spawnPoint.TargetPosition);
        }
    }
}