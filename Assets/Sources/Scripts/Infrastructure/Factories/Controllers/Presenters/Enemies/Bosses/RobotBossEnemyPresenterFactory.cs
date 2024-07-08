using System;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Controllers.Presenters.Enemies.Bosses.States;
using Sources.Scripts.Domain.Models.Enemies.Boss;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.Transitions;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Bosses;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Bosses
{
    public class RobotBossEnemyPresenterFactory
    {
        private readonly IUpdateRegister _updateRegister;

        public RobotBossEnemyPresenterFactory(IUpdateRegister updateRegister)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
        }

        public EnemyPresenter Create(
            BossEnemy enemy,
            KilledEnemiesCounter killedEnemiesCounter,
            IRobotBossEnemyView enemyView,
            IEnemyAnimation enemyAnimation)
        {
            RobotBossAttackState attackState = new RobotBossAttackState(enemy, enemyView, enemyAnimation);
            RobotBossDieState dieState = new RobotBossDieState(killedEnemiesCounter, enemyView, enemyAnimation);

            FiniteTransition toDieTransition = new FiniteTransitionBase(
                dieState, () => enemy.EnemyHealth.CurrentHealth <= 0);
            attackState.AddTransition(toDieTransition);

            return new EnemyPresenter(attackState, _updateRegister);
        }
    }
}