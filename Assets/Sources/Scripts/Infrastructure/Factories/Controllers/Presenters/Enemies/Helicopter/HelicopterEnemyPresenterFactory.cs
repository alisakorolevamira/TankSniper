﻿using System;
using System.Collections.Generic;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Controllers.Presenters.Enemies.Base.States;
using Sources.Scripts.Controllers.Presenters.Enemies.Helicopter;
using Sources.Scripts.Domain.Models.Enemies.Helicopter;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.Transitions;
using Sources.Scripts.InfrastructureInterfaces.Services.Players;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopter;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Helicopter
{
    public class HelicopterEnemyPresenterFactory
    {
        private readonly List<IEnemyViewBase> _enemyCollection;
        private readonly IPlayerAttackService _playerAttackService;
        private readonly IUpdateRegister _updateRegister;

        public HelicopterEnemyPresenterFactory(
            IUpdateRegister updateRegister,
            List<IEnemyViewBase> enemyCollection,
            IPlayerAttackService playerAttackService)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _enemyCollection = enemyCollection ?? throw new ArgumentNullException(nameof(enemyCollection));
            _playerAttackService = playerAttackService ?? throw new ArgumentNullException(nameof(playerAttackService));
        }

        public EnemyPresenter Create(
            HelicopterEnemy enemy,
            KilledEnemiesCounter killedEnemiesCounter,
            IHelicopterEnemyView enemyView,
            IHelicopterEnemyAnimation enemyAnimation)
        {
            EnemyIdleState idleState = new EnemyIdleState(enemyAnimation);
            HelicopterAttackState attackState = new HelicopterAttackState(enemy, enemyView, enemyAnimation);
            EnemyDieState dieState = new EnemyDieState(killedEnemiesCounter, enemyView, _enemyCollection, enemyAnimation);
            
            FiniteTransitionBase toAttackTransition = new FiniteTransitionBase(
                attackState, () => _playerAttackService.PlayerAttacked);
            idleState.AddTransition(toAttackTransition);

            FiniteTransition toDieTransition = new FiniteTransitionBase(
                dieState, () => enemy.EnemyHealth.CurrentHealth <= 0);
            attackState.AddTransition(toDieTransition);

            return new EnemyPresenter(idleState, _updateRegister);
        }
    }
}