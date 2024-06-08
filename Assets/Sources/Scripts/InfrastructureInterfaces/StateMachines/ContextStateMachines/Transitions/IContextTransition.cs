using Sources.Scripts.InfrastructureInterfaces.StateMachines.ContextStateMachines.Contexts;
using Sources.Scripts.InfrastructureInterfaces.StateMachines.ContextStateMachines.States;

namespace Sources.Scripts.InfrastructureInterfaces.StateMachines.ContextStateMachines.Transitions
{
    public interface IContextTransition
    {
        IContextState NextState { get; }

        bool CanTransit(IContext context);
    }
}