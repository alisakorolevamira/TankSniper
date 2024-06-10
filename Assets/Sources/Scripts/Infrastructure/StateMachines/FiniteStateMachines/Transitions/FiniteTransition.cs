using System;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.InfrastructureInterfaces.StateMachines.FiniteStateMachines.Transitions;

namespace Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.Transitions
{
    public abstract class FiniteTransition : IFiniteTransition
    {
        private readonly FiniteState _nextState;

        protected FiniteTransition(FiniteState nextState)
        {
            _nextState = nextState ?? throw new ArgumentNullException(nameof(nextState));
        }

        public bool CanMoveNextState(out FiniteState state)
        {
            state = _nextState;

            return CanTransit();
        }

        protected abstract bool CanTransit();
    }
}