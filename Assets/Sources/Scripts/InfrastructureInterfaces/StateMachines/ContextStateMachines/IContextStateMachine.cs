using Sources.Scripts.InfrastructureInterfaces.StateMachines.ContextStateMachines.Contexts;

namespace Sources.Scripts.InfrastructureInterfaces.StateMachines.ContextStateMachines
{
    public interface IContextStateMachine
    {
        void Apply(IContext context);
    }
}