using System;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Standing;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Standing.States
{
    public class StandingEnemyIdleState : FiniteState
    {
        private readonly IStandingEnemyAnimation _enemyAnimation;
        private readonly IStandingEnemyView _enemyView;

        public StandingEnemyIdleState(
            IStandingEnemyAnimation enemyAnimation,
            IStandingEnemyView enemyView)
        {
            _enemyAnimation = enemyAnimation ?? throw new ArgumentNullException(nameof(enemyAnimation));
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
        }

        public override void Enter()
        {
            _enemyAnimation.PlayIdle();
        }
    }
}