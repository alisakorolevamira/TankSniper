using System;
using System.Collections.Generic;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Controllers.Presenters.Enemies.Base.States;
using Sources.Scripts.Controllers.Presenters.Enemies.Boss.States;
using Sources.Scripts.Domain.Models.Enemies.Boss;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.Transitions;
using Sources.Scripts.InfrastructureInterfaces.Services.Enemies;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss;
using UnityEngine;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Boss
{
    public class BossEnemyPresenterFactory
    {
        private readonly IUpdateRegister _updateRegister;
        private readonly List<IEnemyView> _enemyCollection;
        private readonly IEnemyAttackService _enemyAttackService;

        public BossEnemyPresenterFactory(
            IUpdateRegister updateRegister,
            List<IEnemyView> enemyCollection,
            IEnemyAttackService enemyAttackService)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _enemyCollection = enemyCollection ??
                               throw new ArgumentNullException(nameof(enemyCollection));
            _enemyAttackService = enemyAttackService ??
                                  throw new ArgumentNullException(nameof(enemyAttackService));
        }

        public EnemyPresenter Create(
            BossEnemy bossEnemy,
            KilledEnemiesCounter killedEnemiesCounter,
            IBossEnemyView bossEnemyView,
            IBossEnemyAnimation bossEnemyAnimation)
        {
            EnemyInitializeState initializeState = new EnemyInitializeState(
                bossEnemy, bossEnemyAnimation, bossEnemyView, _enemyCollection);
            BossEnemyAttackState attackState = new BossEnemyAttackState(
                bossEnemy, bossEnemyView, bossEnemyAnimation, _enemyAttackService);
            EnemyDieState dieState = new EnemyDieState(
                killedEnemiesCounter,
                bossEnemyView,
                _enemyCollection);

            //FiniteTransitionBase toAttackTransition = new FiniteTransitionBase(
            //    attackState, () => Vector3.Distance(
            //        bossEnemyView.Position,
            //        bossEnemyView.CharacterMovementView.Position)
            //                       < bossEnemyView.StoppingDistance);
            //initializeState.AddTransition(toAttackTransition);
            

            FiniteTransition toDieTransition = new FiniteTransitionBase(
                dieState, () => bossEnemy.EnemyHealth.CurrentHealth <= 0);
            attackState.AddTransition(toDieTransition);

            return new EnemyPresenter(initializeState, _updateRegister);
        }
    }
}