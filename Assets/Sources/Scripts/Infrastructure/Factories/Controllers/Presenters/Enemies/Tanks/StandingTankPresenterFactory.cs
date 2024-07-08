using System;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Controllers.Presenters.Enemies.Base.States;
using Sources.Scripts.Domain.Models.Enemies.Tanks;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.Transitions;
using Sources.Scripts.InfrastructureInterfaces.Services.Players;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tanks;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Tanks
{
    public class StandingTankPresenterFactory
    {
        private readonly IPlayerAttackService _playerAttackService;
        private readonly IUpdateRegister _updateRegister;

        public StandingTankPresenterFactory(IUpdateRegister updateRegister, IPlayerAttackService playerAttackService)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _playerAttackService = playerAttackService ?? throw new ArgumentNullException(nameof(playerAttackService));
        }

        public EnemyPresenter Create(
            StandingTankEnemy enemy,
            KilledEnemiesCounter killedEnemiesCounter,
            IStandingTankEnemyView tankEnemyView,
            IStandingTankEnemyAnimation enemyAnimation)
        {
            EnemyIdleState idleState = new EnemyIdleState(enemyAnimation);
            EnemyAttackState attackState = new EnemyAttackState(enemy, tankEnemyView, enemyAnimation);
            EnemyDieState dieState = new EnemyDieState(killedEnemiesCounter, tankEnemyView, enemyAnimation);
            
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