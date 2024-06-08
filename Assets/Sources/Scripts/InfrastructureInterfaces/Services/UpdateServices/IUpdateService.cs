using Sources.Scripts.InfrastructureInterfaces.Services.Registers;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices.Methods;

namespace Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices
{
    public interface IUpdateService : IUpdatable, IAllUnregister
    {
    }
}