﻿using System;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Controllers.Presenters.Enemies.Base.States;
using Sources.Scripts.Controllers.Presenters.Enemies.Bosses.States;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.Transitions;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Bosses;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Bosses
{
    public class BoatBossEnemyPresenterFactory
    {
        private readonly IUpdateRegister _updateRegister;

        public BoatBossEnemyPresenterFactory(IUpdateRegister updateRegister)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
        }

        public EnemyPresenter Create(
            Enemy enemy,
            KilledEnemiesCounter killedEnemiesCounter,
            IBoatBossEnemyView enemyView,
            IEnemyAnimation enemyAnimation)
        {
            BoatBossAttackState attackState = new BoatBossAttackState(enemy, enemyView, enemyAnimation);
            EnemyDieState dieState = new EnemyDieState(killedEnemiesCounter, enemyView, enemyAnimation);

            FiniteTransition toDieTransition = new FiniteTransitionBase(
                dieState, () => enemy.EnemyHealth.CurrentHealth <= EnemyConst.MinHealth);
            attackState.AddTransition(toDieTransition);

            return new EnemyPresenter(attackState, _updateRegister);
        }
    }
}