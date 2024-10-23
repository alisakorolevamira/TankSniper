using System;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.PauseServices;
using Sources.Scripts.PresentationsInterfaces.Views.Music;

namespace Sources.Scripts.Controllers.Presenters.Music
{
    public class BackgroundMusicPresenter : PresenterBase
    {
        private readonly IBackgroundMusicView _backgroundMusicView;
        private readonly IVolumeService _volumeService;
        private readonly IPauseService _pauseService;
        
        private float _savedTime;

        public BackgroundMusicPresenter(
            IBackgroundMusicView backgroundMusicView,
            IVolumeService volumeService,
            IPauseService pauseService)
        {
            _backgroundMusicView = backgroundMusicView ?? throw new ArgumentNullException(nameof(backgroundMusicView));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
        }

        public override void Enable()
        {
            _pauseService.PauseSoundActivated += OnPauseSoundActivated;
            _pauseService.ContinueSoundActivated += OnContinueSoundActivated;
            _volumeService.VolumeChanged += OnMusicVolumeChanged;
            StartMusic();
        }

        public override void Disable()
        {
            _pauseService.PauseSoundActivated -= OnPauseSoundActivated;
            _pauseService.ContinueSoundActivated -= OnContinueSoundActivated;
            _volumeService.VolumeChanged -= OnMusicVolumeChanged;
        }

        private void OnPauseSoundActivated()
        {
            _savedTime = _backgroundMusicView.BackgroundMusicAudioSource.Time;
            _backgroundMusicView.BackgroundMusicAudioSource.Pause();
        }

        private void OnContinueSoundActivated()
        {
            _backgroundMusicView.BackgroundMusicAudioSource.SetTime(_savedTime);
            _backgroundMusicView.BackgroundMusicAudioSource.UnPause();
        }

        private void OnMusicVolumeChanged(int volume) =>
            _backgroundMusicView.BackgroundMusicAudioSource.SetVolume(volume);

        private void StartMusic()
        {
            IAudioSourceView audioSourceView = _backgroundMusicView.BackgroundMusicAudioSource;
            audioSourceView.Play();
        }
    }
}