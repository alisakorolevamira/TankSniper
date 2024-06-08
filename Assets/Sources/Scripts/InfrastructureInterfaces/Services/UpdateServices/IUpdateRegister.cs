using System;
using Sources.Scripts.InfrastructureInterfaces.Services.Registers;

namespace Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices
{
    public interface IUpdateRegister : IActionRegister<float>
    {
        event Action<float> UpdateChanged;
    }
}