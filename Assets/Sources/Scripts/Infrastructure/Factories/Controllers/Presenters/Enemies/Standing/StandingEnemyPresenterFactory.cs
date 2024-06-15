﻿using System;
using System.Collections.Generic;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Controllers.Presenters.Enemies.Standing.States;
using Sources.Scripts.Domain.Models.Enemies.Standing;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.Transitions;
using Sources.Scripts.InfrastructureInterfaces.Services.Players;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Standing;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Standing
{
    public class StandingEnemyPresenterFactory
    {
        private readonly List<IEnemyViewBase> _enemyCollection;
        private readonly IPlayerAttackService _playerAttackService;
        private readonly IUpdateRegister _updateRegister;

        public StandingEnemyPresenterFactory(
            IUpdateRegister updateRegister,
            List<IEnemyViewBase> enemyCollection,
            IPlayerAttackService playerAttackService)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _enemyCollection = enemyCollection ?? throw new ArgumentNullException(nameof(enemyCollection));
            _playerAttackService = playerAttackService ?? throw new ArgumentNullException(nameof(playerAttackService));
        }

        public EnemyPresenter Create(
            StandingEnemy enemy,
            KilledEnemiesCounter killedEnemiesCounter,
            IStandingEnemyView enemyView,
            IStandingEnemyAnimation enemyAnimation,
            IEnemySpawnPoint spawnPoint)
        {
            StandingEnemyIdleState idleState = new StandingEnemyIdleState(enemyAnimation, enemyView);
            StandingEnemyAttackState attackState = new StandingEnemyAttackState(enemy, enemyView, enemyAnimation);
            StandingEnemyDieState dieState = new StandingEnemyDieState(killedEnemiesCounter, enemyView, _enemyCollection, enemyAnimation);
            
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