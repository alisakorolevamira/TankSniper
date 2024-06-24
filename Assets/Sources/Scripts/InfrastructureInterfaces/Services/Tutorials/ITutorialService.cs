using Sources.Scripts.ControllersInterfaces.ControllerLifetimes;
using Sources.Scripts.Domain.Models.Gameplay;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Tutorials
{
    public interface ITutorialService : IEnable
    {
        bool IsCompleted { get; }
        void Complete();
        void Construct(Tutorial tutorial);
    }
}