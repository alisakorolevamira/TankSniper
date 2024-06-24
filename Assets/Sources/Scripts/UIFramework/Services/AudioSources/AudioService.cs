using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.UIFramework.Presentations.AudioSources.Types;
using Sources.Scripts.UIFramework.PresentationsInterfaces.AudioSources;
using Sources.Scripts.UIFramework.ServicesInterfaces.AudioSources;

namespace Sources.Scripts.UIFramework.Services.AudioSources
{
    public class AudioService : IAudioService
    {
        private readonly IVolumeService _volumeService;
        private readonly Dictionary<AudioSourceId, IUIAudioSource> _audioSources;

        public AudioService(
            IHud hud,
            IVolumeService volumeService)
        {
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _audioSources = hud.UIAudioSources.ToDictionary(
                uiAudioSource => uiAudioSource.AudioSourceId, uiAudioSource => uiAudioSource);
        }

        public void Enter(object payload = null)
        {
            OnVolumeChanged(_volumeService.Volume);
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

        private void OnVolumeChanged(int volume)
        {
            foreach (IUIAudioSource audioSource in _audioSources.Values)
                audioSource.SetVolume(volume);
        }
    }
}