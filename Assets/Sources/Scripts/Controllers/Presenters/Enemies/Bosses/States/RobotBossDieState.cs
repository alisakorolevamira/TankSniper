using System;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Bosses;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Bosses.States
{
    public class RobotBossDieState : FiniteState
    {
        private readonly KilledEnemiesCounter _killedEnemiesCounter;
        private readonly IRobotBossEnemyView _enemyView;
        private readonly IEnemyAnimation _enemyAnimation;

        public RobotBossDieState(
            KilledEnemiesCounter killedEnemiesCounter,
            IRobotBossEnemyView enemyView,
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
            _enemyView.Explode();
        }
    }
}