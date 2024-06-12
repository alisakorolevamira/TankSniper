using System;
using JetBrains.Annotations;
using Sources.Scripts.ControllersInterfaces.Presenters;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.InfrastructureInterfaces.Services.InputServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Players;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Base
{
    public class EnemyPresenter : FiniteStateMachine, IPresenter
    {
        private readonly FiniteState _firstState;
        private readonly FiniteState _dieState;
        private readonly IUpdateRegister _updateRegister;

        public EnemyPresenter(
            FiniteState firstState,
            IUpdateRegister updateRegister)
        {
            _firstState = firstState ?? throw new ArgumentNullException(nameof(firstState));
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
        }

        public void Enable()
        {
            Start(_firstState);
            _updateRegister.UpdateChanged += Update;
        }

        public void Disable()
        {
            Stop();
            _updateRegister.UpdateChanged -= Update;
        }
    }
}