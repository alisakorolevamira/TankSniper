using Sources.Scripts.ControllersInterfaces.ControllerLifetimes;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices.Methods;
using Sources.Scripts.InfrastructureInterfaces.StateMachines.ContextStateMachines.Contexts;

namespace Sources.Scripts.InfrastructureInterfaces.StateMachines.ContextStateMachines.States
{
    public interface IContextState : IEnterable, IExitable, IUpdatable
    {
        void Apply(IContext context, IContextStateChanger contextStateChanger);
    }
}