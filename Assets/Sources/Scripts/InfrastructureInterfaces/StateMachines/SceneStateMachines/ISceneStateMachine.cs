using Sources.Scripts.ControllersInterfaces.ControllerLifetimes;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices.Methods;
using Sources.Scripts.InfrastructureInterfaces.StateMachines.States;

namespace Sources.Scripts.InfrastructureInterfaces.StateMachines.SceneStateMachines
{
    public interface ISceneStateMachine : IUpdatable, ILateUpdatable, IFixedUpdatable, IExitable
    {
        void ChangeState(IState state, object payload = null);
    }
}