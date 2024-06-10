using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;

namespace Sources.Scripts.InfrastructureInterfaces.StateMachines.FiniteStateMachines.Transitions
{
    public interface IFiniteTransition
    {
        bool CanMoveNextState(out FiniteState nextState);
    }
}