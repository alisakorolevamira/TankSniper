using Sources.Scripts.ControllersInterfaces.ControllerLifetimes;
using Sources.Scripts.DomainInterfaces.Models.Common;
using Sources.Scripts.DomainInterfaces.Models.Players;

namespace Sources.Scripts.InfrastructureInterfaces.Services.GameOver
{
    public interface IGameOverService : IEnterable, IExitable
    {
        void Register(ICharacterHealth characterHealth);
    }
}