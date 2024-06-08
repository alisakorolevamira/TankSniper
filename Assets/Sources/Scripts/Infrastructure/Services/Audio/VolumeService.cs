using System;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;

namespace Sources.Scripts.Infrastructure.Services.Audio
{
    public class VolumeService : IVolumeService
    {
        private Volume _volume;

        public event Action VolumeChanged;

        public int Volume => _volume.AudioVolume;

        public void Enter(object payload = null)
        {
            OnVolumeChanged();
            _volume.AudioVolumeChanged += OnVolumeChanged;
        }

        public void Exit()
        {
            _volume.AudioVolumeChanged -= OnVolumeChanged;
        }

        private void OnVolumeChanged() =>
            VolumeChanged?.Invoke();

        public void Register(Volume volume) =>
            _volume = volume ?? throw new ArgumentNullException(nameof(volume));
    }
}