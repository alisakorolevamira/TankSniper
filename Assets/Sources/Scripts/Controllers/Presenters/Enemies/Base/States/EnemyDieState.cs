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
        private readonly IEnemyViewBase _enemyView;
        private readonly List<IEnemyViewBase> _enemyCollection;

        public EnemyDieState(
            KilledEnemiesCounter killedEnemiesCounter,
            IEnemyViewBase enemyView,
            List<IEnemyViewBase> enemyCollection)
        {
            _killedEnemiesCounter = killedEnemiesCounter ?? throw new ArgumentNullException(nameof(killedEnemiesCounter));
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _enemyCollection = enemyCollection ?? throw new ArgumentNullException(nameof(enemyCollection));
        }

        public override void Enter()
        {
            if (_enemyView == null)
                return;

            _killedEnemiesCounter.IncreaseKilledEnemiesCount();
            _enemyCollection.Remove(_enemyView);
            _enemyView.Destroy();
        }
    }
}