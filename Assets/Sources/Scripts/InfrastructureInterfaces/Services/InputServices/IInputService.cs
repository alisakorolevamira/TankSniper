using Sources.Scripts.Domain.Models.Inputs;

namespace Sources.Scripts.InfrastructureInterfaces.Services.InputServices
{
    public interface IInputService
    {
        InputData InputData { get; }
    }
}