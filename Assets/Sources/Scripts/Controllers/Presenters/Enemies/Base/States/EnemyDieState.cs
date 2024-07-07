using System;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Base.States
{
    public class EnemyDieState : FiniteState
    {
        private readonly KilledEnemiesCounter _killedEnemiesCounter;
        private readonly IEnemyViewBase _enemyView;
        private readonly IEnemyAnimation _enemyAnimation;

        public EnemyDieState(
            KilledEnemiesCounter killedEnemiesCounter,
            IEnemyViewBase enemyView,
            IEnemyAnimation enemyAnimation)
        {
            _killedEnemiesCounter = killedEnemiesCounter ?? throw new ArgumentNullException(nameof(killedEnemiesCounter));
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _enemyAnimation = enemyAnimation ?? throw new ArgumentNullException(nameof(enemyAnimation));
        }

        public override void Enter()
        {
            if (_enemyView == null)
                return;

            _killedEnemiesCounter.IncreaseKilledEnemiesCount();
            _enemyAnimation.PlayDying();
        }
    }
}