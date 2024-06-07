using Sources.Scripts.ControllersInterfaces.ControllerLifetimes;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices.Methods;

namespace Sources.Scripts.InfrastructureInterfaces.StateMachines.States
{
    public interface IState : IEnterable, IExitable, IUpdatable, ILateUpdatable, IFixedUpdatable
    {
    }
}