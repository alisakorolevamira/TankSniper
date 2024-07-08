using System;
using Sources.Scripts.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Controllers.Presenters.Enemies.Base.States;
using Sources.Scripts.Controllers.Presenters.Enemies.Dron.States;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Domain.Models.Enemies.Dron;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.Transitions;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Dron;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Dron
{
    public class DronEnemyPresenterFactory
    {
        private readonly IUpdateRegister _updateRegister;

        public DronEnemyPresenterFactory(IUpdateRegister updateRegister)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
        }

        public EnemyPresenter Create(
            Enemy enemy,
            KilledEnemiesCounter killedEnemiesCounter,
            IDronEnemyView enemyView,
            IEnemyAnimation enemyAnimation)
        {
            DronAttackState attackState = new DronAttackState(enemyAnimation, enemyView, enemy);
            EnemyDieState dieState = new EnemyDieState(killedEnemiesCounter, enemyView, enemyAnimation);

            FiniteTransition toDieTransition = new FiniteTransitionBase(
                dieState, () => enemy.EnemyHealth.CurrentHealth <= 0);
            attackState.AddTransition(toDieTransition);

            return new EnemyPresenter(attackState, _updateRegister);
        }
    }
}