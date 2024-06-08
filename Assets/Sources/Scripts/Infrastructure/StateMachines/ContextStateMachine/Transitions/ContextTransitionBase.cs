using System;
using Sources.Scripts.InfrastructureInterfaces.StateMachines.ContextStateMachines.Contexts;
using Sources.Scripts.InfrastructureInterfaces.StateMachines.ContextStateMachines.States;
using Sources.Scripts.InfrastructureInterfaces.StateMachines.ContextStateMachines.Transitions;

namespace Sources.Scripts.Infrastructure.StateMachines.ContextStateMachine.Transitions
{
    public abstract class ContextTransitionBase : IContextTransition
    {
        protected ContextTransitionBase(IContextState nextState)
        {
            NextState = nextState ?? throw new ArgumentNullException(nameof(nextState));
        }
        
        public IContextState NextState { get; }

        public abstract bool CanTransit(IContext context);
    }
}