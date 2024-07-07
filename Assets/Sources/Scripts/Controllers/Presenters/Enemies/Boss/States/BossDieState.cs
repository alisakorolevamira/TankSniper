using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Boss.States
{
    public class BossDieState : FiniteState
    {
        private readonly KilledEnemiesCounter _killedEnemiesCounter;
        private readonly IBossEnemyView _enemyView;
        private readonly IBossEnemyAnimation _enemyAnimation;

        public BossDieState(
            KilledEnemiesCounter killedEnemiesCounter,
            IBossEnemyView enemyView,
            IBossEnemyAnimation enemyAnimation)
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