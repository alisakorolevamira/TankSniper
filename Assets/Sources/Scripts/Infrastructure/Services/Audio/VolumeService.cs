using System;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;

namespace Sources.Scripts.Infrastructure.Services.Audio
{
    public class VolumeService : IVolumeService
    {
        private Volume _volume;

        public event Action<int> VolumeChanged;

        public int Volume => _volume.AudioVolume;

        public void Enter(object payload = null)
        {
            OnVolumeChanged();
        }

        public void Exit()
        {
        }

        public void SetVolume()
        {
            if (_volume.AudioVolume == 0)
                _volume.AudioVolume = 1;

            else
                _volume.AudioVolume = 0;
            
            VolumeChanged?.Invoke(Volume);
        }

        private void OnVolumeChanged() =>
            VolumeChanged?.Invoke(Volume);

        public void Register(Volume volume) =>
            _volume = volume ?? throw new ArgumentNullException(nameof(volume));
    }
}