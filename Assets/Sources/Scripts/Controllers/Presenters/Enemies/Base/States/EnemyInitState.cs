using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Base.States
{
    public class EnemyInitState : FiniteState
    {
        private readonly Enemy _enemy;
        private readonly IEnemyAnimation _enemyAnimation;
        private readonly ITankEnemyView tankEnemyView;
        private readonly List<ITankEnemyView> _enemyCollection;

        public EnemyInitState(
            Enemy enemy,
            IEnemyAnimation enemyAnimation,
            ITankEnemyView tankEnemyView,
            List<ITankEnemyView> enemyCollection)
        {
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _enemyAnimation = enemyAnimation;
            this.tankEnemyView = tankEnemyView ?? throw new ArgumentNullException(nameof(tankEnemyView));
            _enemyCollection = enemyCollection ?? throw new ArgumentNullException(nameof(enemyCollection));
        }

        public override void Enter()
        {
            _enemy.IsInitialized = true;
            _enemyAnimation.PlayIdle();
            _enemyCollection.Add(tankEnemyView);
        }
    }
}