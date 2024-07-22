using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.PresentationsInterfaces.Views.Settings;

namespace Sources.Scripts.Controllers.Presenters.Settings
{
    public class VolumePresenter : PresenterBase
    {
        private readonly IVolumeService _volumeService;
        private readonly IVolumeView _volumeView;

        public VolumePresenter(IVolumeService volumeService, IVolumeView volumeView)
        {
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _volumeView = volumeView ?? throw new ArgumentNullException(nameof(volumeView));
        }
        
        public override void Enable() => 
            _volumeService.VolumeChanged += SetVolume;

        public override void Disable() => 
            _volumeService.VolumeChanged -= SetVolume;

        private void SetVolume(int volume) => 
            _volumeView.ImageView.SetSprite(volume == VolumeConst.OffAudioValue ? _volumeView.VolumeOffSprite : _volumeView.VolumeOnSprite);
    }
}