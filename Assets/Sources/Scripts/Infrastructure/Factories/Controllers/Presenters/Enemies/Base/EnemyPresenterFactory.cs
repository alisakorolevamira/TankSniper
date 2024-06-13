﻿using System;
using System.Collections.Generic;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Controllers.Presenters.Enemies.Base.States;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.Transitions;
using Sources.Scripts.InfrastructureInterfaces.Services.Players;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Base
{
    public class EnemyPresenterFactory
    {
        private readonly List<IEnemyViewBase> _enemyCollection;
        private readonly IPlayerAttackService _playerAttackService;
        private readonly IUpdateRegister _updateRegister;

        public EnemyPresenterFactory(
            IUpdateRegister updateRegister,
            List<IEnemyViewBase> enemyCollection,
            IPlayerAttackService playerAttackService)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _enemyCollection = enemyCollection ?? throw new ArgumentNullException(nameof(enemyCollection));
            _playerAttackService = playerAttackService ?? throw new ArgumentNullException(nameof(playerAttackService));
        }

        public EnemyPresenter Create(
            Enemy enemy,
            KilledEnemiesCounter killedEnemiesCounter,
            IEnemyViewBase enemyView,
            IEnemyAnimation enemyAnimation,
            IEnemySpawnPoint spawnPoint)
        {
            //EnemyInitState initState = new EnemyInitState(enemy, enemyAnimation, enemyView, _enemyCollection);
            EnemyAttackState attackState = new EnemyAttackState(enemy, enemyView, enemyAnimation);
            EnemyDieState dieState = new EnemyDieState(killedEnemiesCounter, enemyView, _enemyCollection);
            
            FiniteTransitionBase toAttackTransition = new FiniteTransitionBase(
                attackState, () => _playerAttackService.PlayerAttacked);

            FiniteTransition toDieTransition = new FiniteTransitionBase(
                dieState, () => enemy.EnemyHealth.CurrentHealth <= 0);
            attackState.AddTransition(toDieTransition);

            return new EnemyPresenter(attackState, _updateRegister);
        }
    }
}