using System;
using System.Threading;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.PauseServices;
using Sources.Scripts.PresentationsInterfaces.Views.Music;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.Music
{
    public class BackgroundMusicPresenter : PresenterBase
    {
        private readonly IBackgroundMusicView _backgroundMusicView;
        private readonly IVolumeService _volumeService;
        private readonly IPauseService _pauseService;

        private CancellationTokenSource _cancellationTokenSource;
        //private TimeSpan _waitTimeSpan = TimeSpan.FromSeconds(BackGroundMusicConst.WaitDaley);
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
            _cancellationTokenSource = new CancellationTokenSource();
            _pauseService.PauseSoundActivated += OnPauseSoundActivated;
            _pauseService.ContinueSoundActivated += OnContinueSoundActivated;
            _volumeService.VolumeChanged += OnMusicVolumeChanged;
            StartMusic(_cancellationTokenSource.Token);
        }

        public override void Disable()
        {
            _pauseService.PauseSoundActivated -= OnPauseSoundActivated;
            _pauseService.ContinueSoundActivated -= OnContinueSoundActivated;
            _volumeService.VolumeChanged -= OnMusicVolumeChanged;
            _cancellationTokenSource.Cancel();
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

        private async void StartMusic(CancellationToken cancellationToken)
        {
            IAudioSourceView audioSourceView = _backgroundMusicView.BackgroundMusicAudioSource;
            audioSourceView.Play();
            
           // try
           // {
           //     while (cancellationToken.IsCancellationRequested == false)
           //     {
           //         foreach (AudioClip audioClip in audioClips)
           //         {
           //             audioSourceView.SetClip(audioClip);
           //             audioSourceView.Play();
           //             await WaitEnd(audioClip, audioSourceView, cancellationToken);
           //         }
           //     }
           // }
           // catch (OperationCanceledException)
           // {
           // }
        }

       // private async UniTask WaitEnd(
       //     AudioClip audioClip, 
       //     IAudioSourceView audioSourceView, 
       //     CancellationToken cancellationToken)
       // {
       //     while (audioSourceView.Time + BackGroundMusicConst.CorrectOffset < audioClip.length)
       //     {
       //         await UniTask.Delay(_waitTimeSpan, 
       //             ignoreTimeScale: true, 
       //             cancellationToken: cancellationToken);
       //     }
       // }
    }
}