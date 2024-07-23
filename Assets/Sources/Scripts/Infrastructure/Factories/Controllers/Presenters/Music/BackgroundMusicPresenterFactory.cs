using System;
using Sources.Scripts.Controllers.Presenters.Music;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.PauseServices;
using Sources.Scripts.PresentationsInterfaces.Views.Music;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Music
{
    public class BackgroundMusicPresenterFactory
    {
        private readonly IVolumeService _volumeService;
        private readonly IPauseService _pauseService;

        public BackgroundMusicPresenterFactory(
            IVolumeService volumeService,
            IPauseService pauseService)
        {
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
        }

        public BackgroundMusicPresenter Create(IBackgroundMusicView backgroundMusicView) => 
            new(backgroundMusicView, _volumeService, _pauseService);
    }
}