using Sources.Scripts.InfrastructureInterfaces.StateMachines.ContextStateMachines.States;

namespace Sources.Scripts.InfrastructureInterfaces.StateMachines.ContextStateMachines
{
    public interface IContextStateChanger
    {
        void ChangeState(IContextState state);
    }
}