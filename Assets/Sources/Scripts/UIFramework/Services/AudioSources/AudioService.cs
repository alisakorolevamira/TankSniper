using System;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.UIFramework.PresentationsInterfaces.AudioSources;
using Sources.Scripts.UIFramework.ServicesInterfaces.AudioSources;

namespace Sources.Scripts.UIFramework.Services.AudioSources
{
    public class AudioService : IAudioService
    {
        private readonly IVolumeService _volumeService;
        private readonly IUIAudioSource _audioSource;

        public AudioService(
            IHud hud,
            IVolumeService volumeService)
        {
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _audioSource = hud.UIAudioSource ?? throw new ArgumentNullException(nameof(hud));
        }

        public void Enter(object payload = null)
        {
            OnVolumeChanged(_volumeService.Volume);
            _volumeService.VolumeChanged += OnVolumeChanged;
        }

        public void Exit() =>
            _volumeService.VolumeChanged -= OnVolumeChanged;

        public void Play() => 
            _audioSource.Play();

        private void OnVolumeChanged(int volume) => 
            _audioSource.SetVolume(volume);
    }
}