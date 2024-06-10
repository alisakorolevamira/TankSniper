using System;
using System.Collections.Generic;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Controllers.Presenters.Enemies.Base.States;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.Transitions;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Base
{
    public class EnemyPresenterFactory
    {
        private readonly IUpdateRegister _updateRegister;
        private readonly List<IEnemyView> _enemyCollection;

        public EnemyPresenterFactory(
            IUpdateRegister updateRegister,
            List<IEnemyView> enemyCollection)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _enemyCollection = enemyCollection ?? throw new ArgumentNullException(nameof(enemyCollection));
        }

        public EnemyPresenter Create(
            Enemy enemy,
            KilledEnemiesCounter killedEnemiesCounter,
            IEnemyView enemyView,
            IEnemyAnimation enemyAnimation)
        {
            EnemyInitializeState initializeState = new EnemyInitializeState(
                enemy, enemyAnimation, enemyView, _enemyCollection);
            EnemyAttackState attackState = new EnemyAttackState(enemy, enemyView, enemyAnimation);
            EnemyDieState dieState = new EnemyDieState(
                killedEnemiesCounter,
                enemyView,
                _enemyCollection);
            
            //FiniteTransitionBase toAttackTransition = new FiniteTransitionBase(
            //    attackState, () => Vector3.Distance(
            //        enemyView.Position, enemyView.CharacterMovementView.Position) < enemyView.StoppingDistance);
            //initializeState.AddTransition(toAttackTransition);

            FiniteTransition toDieTransition = new FiniteTransitionBase(
                dieState, () => enemy.EnemyHealth.CurrentHealth <= 0);
            attackState.AddTransition(toDieTransition);

            return new EnemyPresenter(
                initializeState,
                _updateRegister);
        }
    }
}