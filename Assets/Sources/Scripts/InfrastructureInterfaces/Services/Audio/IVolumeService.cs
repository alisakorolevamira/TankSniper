using System;
using Sources.Scripts.ControllersInterfaces.ControllerLifetimes;
using Sources.Scripts.Domain.Models.Settings;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Audio
{
    public interface IVolumeService : IEnterable, IExitable
    {
        event Action VolumeChanged;
        
        int Volume { get; }
        
        void Register(Volume volume);
    }
}