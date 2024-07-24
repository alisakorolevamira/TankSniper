using System;
using Sources.Scripts.Domain.Models.Constants;
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
            _volume.AudioVolume = _volume.AudioVolume == VolumeConst.OffAudioValue ?
                VolumeConst.BaseAudioValue : VolumeConst.OffAudioValue;

            VolumeChanged?.Invoke(Volume);
        }

        private void OnVolumeChanged() =>
            VolumeChanged?.Invoke(Volume);

        public void Register(Volume volume) =>
            _volume = volume ?? throw new ArgumentNullException(nameof(volume));
    }
}