using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Base.States
{
    public class EnemyDieState : FiniteState
    {
        private readonly KilledEnemiesCounter _killedEnemiesCounter;
        private readonly ITankEnemyView tankEnemyView;
        private readonly List<ITankEnemyView> _enemyCollection;

        public EnemyDieState(
            KilledEnemiesCounter killedEnemiesCounter,
            ITankEnemyView tankEnemyView,
            List<ITankEnemyView> enemyCollection)
        {
            _killedEnemiesCounter =
                killedEnemiesCounter ?? throw new ArgumentNullException(nameof(killedEnemiesCounter));
            this.tankEnemyView = tankEnemyView ?? throw new ArgumentNullException(nameof(tankEnemyView));
            _enemyCollection = enemyCollection ?? throw new ArgumentNullException(nameof(enemyCollection));
        }

        public override void Enter()
        {
            if (tankEnemyView == null)
                return;

            _killedEnemiesCounter.IncreaseKilledEnemiesCount();
            _enemyCollection.Remove(tankEnemyView);
            tankEnemyView.Destroy();
        }
    }
}