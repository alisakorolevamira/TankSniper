using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Base.States
{
    public class EnemyInitState : FiniteState
    {
        private readonly Enemy _enemy;
        private readonly IEnemyAnimation _enemyAnimation;
        private readonly IEnemyView _enemyView;
        private readonly List<IEnemyView> _enemyCollection;

        public EnemyInitState(
            Enemy enemy,
            IEnemyAnimation enemyAnimation,
            IEnemyView enemyView,
            List<IEnemyView> enemyCollection)
        {
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _enemyAnimation = enemyAnimation;
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _enemyCollection = enemyCollection ?? throw new ArgumentNullException(nameof(enemyCollection));
        }

        public override void Enter()
        {
            _enemy.IsInitialized = true;
            _enemyAnimation.PlayIdle();
            _enemyCollection.Add(_enemyView);
        }
    }
}