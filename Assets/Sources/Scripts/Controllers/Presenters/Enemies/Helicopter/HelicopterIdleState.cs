using System;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopters;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Helicopter
{
    public class HelicopterIdleState : FiniteState
    {
        private readonly IHelicopterEnemyView _enemyView;
        private readonly IEnemyAnimation _enemyAnimation;

        public HelicopterIdleState(
            IHelicopterEnemyView enemyView,
            IEnemyAnimation enemyAnimation)
        {
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _enemyAnimation = enemyAnimation ?? throw new ArgumentNullException(nameof(enemyAnimation));
        }
        
        public override void Update(float deltaTime)
        {
            _enemyAnimation.PlayIdle();
            _enemyView.RotateRotor();
        }
    }
}