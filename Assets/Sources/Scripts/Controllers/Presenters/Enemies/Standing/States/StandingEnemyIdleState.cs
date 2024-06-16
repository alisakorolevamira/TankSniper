using System;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Standing;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Standing.States
{
    public class StandingEnemyIdleState : FiniteState
    {
        private readonly IStandingEnemyAnimation _enemyAnimation;

        public StandingEnemyIdleState(IStandingEnemyAnimation enemyAnimation)
        {
            _enemyAnimation = enemyAnimation ?? throw new ArgumentNullException(nameof(enemyAnimation));
        }

        public override void Enter()
        {
            _enemyAnimation.PlayIdle();
        }
    }
}