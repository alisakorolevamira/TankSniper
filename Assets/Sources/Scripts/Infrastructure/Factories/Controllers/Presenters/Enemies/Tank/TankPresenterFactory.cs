using System;
using System.Collections.Generic;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Controllers.Presenters.Enemies.Base.States;
using Sources.Scripts.Controllers.Presenters.Enemies.Tank.States;
using Sources.Scripts.Domain.Models.Enemies.Tank;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.Transitions;
using Sources.Scripts.InfrastructureInterfaces.Services.Players;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Tank
{
    public class TankPresenterFactory
    {
        private readonly List<IEnemyViewBase> _enemyCollection;
        private readonly IPlayerAttackService _playerAttackService;
        private readonly IUpdateRegister _updateRegister;

        public TankPresenterFactory(
            IUpdateRegister updateRegister,
            List<IEnemyViewBase> enemyCollection,
            IPlayerAttackService playerAttackService)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _enemyCollection = enemyCollection ?? throw new ArgumentNullException(nameof(enemyCollection));
            _playerAttackService = playerAttackService ?? throw new ArgumentNullException(nameof(playerAttackService));
        }

        public EnemyPresenter Create(
            TankEnemy enemy,
            KilledEnemiesCounter killedEnemiesCounter,
            ITankEnemyView tankEnemyView,
            ITankEnemyAnimation enemyAnimation)
        {
            TankMovementState movementState = new TankMovementState(enemyAnimation, tankEnemyView);
            EnemyAttackState attackState = new EnemyAttackState(enemy, tankEnemyView, enemyAnimation);
            EnemyDieState dieState = new EnemyDieState(killedEnemiesCounter, tankEnemyView, _enemyCollection, enemyAnimation);
            
            FiniteTransitionBase toAttackTransition = new FiniteTransitionBase(
                attackState, () => _playerAttackService.PlayerAttacked);
            movementState.AddTransition(toAttackTransition);

            FiniteTransition toDieTransition = new FiniteTransitionBase(
                dieState, () => enemy.EnemyHealth.CurrentHealth <= 0);
            attackState.AddTransition(toDieTransition);

            return new EnemyPresenter(movementState, _updateRegister);
        }
    }
}