using System;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.PresentationsInterfaces.Views.Settings;

namespace Sources.Scripts.Controllers.Presenters.Settings
{
    public class VolumePresenter : PresenterBase
    {
        private readonly Volume _volume;
        private readonly IVolumeView _volumeView;

        public VolumePresenter(Volume volume, IVolumeView volumeView)
        {
            _volume = volume ?? throw new ArgumentNullException(nameof(volume));
            _volumeView = volumeView ?? throw new ArgumentNullException(nameof(volumeView));
        }
        
        public override void Enable()
        {
            _volumeView.VolumeButton.AddClickListener(SetVolume);
        }

        public override void Disable()
        {
            _volumeView.VolumeButton.RemoveClickListener(SetVolume);
        }

        private void SetVolume()
        {
            if (_volume.AudioVolume == 0)
            {
                _volume.AudioVolume = 1;
                _volumeView.ImageView.SetSprite(_volumeView.VolumeOnSprite);
            }

            else
            {
                _volume.AudioVolume = 0;
                _volumeView.ImageView.SetSprite(_volumeView.VolumeOffSprite);
            }
        }
    }
}