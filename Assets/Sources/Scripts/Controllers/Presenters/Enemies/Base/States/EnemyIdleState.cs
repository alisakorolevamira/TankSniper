using System;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Base.States
{
    public class EnemyIdleState : FiniteState
    {
        private readonly IEnemyAnimation _enemyAnimation;

        public EnemyIdleState(IEnemyAnimation enemyAnimation)
        {
            _enemyAnimation = enemyAnimation ?? throw new ArgumentNullException(nameof(enemyAnimation));
        }

        public override void Enter() => 
            _enemyAnimation.PlayIdle();
    }
}