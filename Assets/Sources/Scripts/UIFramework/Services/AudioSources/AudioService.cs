using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Scripts.InfrastructureInterfaces.Services.Volumes;
using Sources.Scripts.UIFramework.Presentations.AudioSources.Types;
using Sources.Scripts.UIFramework.Presentations.Views;
using Sources.Scripts.UIFramework.PresentationsInterfaces.AudioSources;
using Sources.Scripts.UIFramework.ServicesInterfaces.AudioSources;

namespace Sources.Scripts.UIFramework.Services.AudioSources
{
    public class AudioService : IAudioService
    {
        private readonly IVolumeService _volumeService;
        private readonly Dictionary<AudioSourceId, IUIAudioSource> _audioSources;

        public AudioService(
            UICollector uiCollector,
            IVolumeService volumeService)
        {
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _audioSources = uiCollector.UIAudioSources.ToDictionary(
                uiAudioSource => uiAudioSource.AudioSourceId, uiAudioSource => uiAudioSource);
        }

        public void Enter(object payload = null)
        {
            OnVolumeChanged();
            _volumeService.VolumeChanged += OnVolumeChanged;
        }

        public void Exit() =>
            _volumeService.VolumeChanged -= OnVolumeChanged;

        public void Play(AudioSourceId id)
        {
            if (_audioSources.ContainsKey(id) == false)
                throw new KeyNotFoundException(id.ToString());

            _audioSources[id].Play();
        }

        private void OnVolumeChanged()
        {
            foreach (IUIAudioSource audioSource in _audioSources.Values)
                audioSource.SetVolume(_volumeService.Volume);
        }
    }
}