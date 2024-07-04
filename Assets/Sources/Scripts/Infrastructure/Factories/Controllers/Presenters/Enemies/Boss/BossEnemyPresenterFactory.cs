using System;
using System.Collections.Generic;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Controllers.Presenters.Enemies.Base.States;
using Sources.Scripts.Controllers.Presenters.Enemies.Boss.States;
using Sources.Scripts.Controllers.Presenters.Enemies.Tank.States;
using Sources.Scripts.Domain.Models.Enemies.Boss;
using Sources.Scripts.Domain.Models.Enemies.Tank;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.Transitions;
using Sources.Scripts.InfrastructureInterfaces.Services.Players;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Boss
{
    public class BossEnemyPresenterFactory
    {
        private readonly List<IEnemyViewBase> _enemyCollection;
        private readonly IPlayerAttackService _playerAttackService;
        private readonly IUpdateRegister _updateRegister;

        public BossEnemyPresenterFactory(
            IUpdateRegister updateRegister,
            List<IEnemyViewBase> enemyCollection,
            IPlayerAttackService playerAttackService)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _enemyCollection = enemyCollection ?? throw new ArgumentNullException(nameof(enemyCollection));
            _playerAttackService = playerAttackService ?? throw new ArgumentNullException(nameof(playerAttackService));
        }

        public EnemyPresenter Create(
            BossEnemy enemy,
            KilledEnemiesCounter killedEnemiesCounter,
            IBossEnemyView enemyView,
            IBossEnemyAnimation enemyAnimation)
        {
            BossMovementState movementState = new BossMovementState(enemyAnimation, enemyView);
            EnemyAttackState attackState = new EnemyAttackState(enemy, enemyView, enemyAnimation);
            EnemyDieState dieState = new EnemyDieState(killedEnemiesCounter, enemyView, _enemyCollection, enemyAnimation);
            
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