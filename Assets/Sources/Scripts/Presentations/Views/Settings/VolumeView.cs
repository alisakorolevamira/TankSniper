using Sources.Scripts.Controllers.Presenters.Settings;
using Sources.Scripts.Presentations.UI.Buttons;
using Sources.Scripts.Presentations.UI.Images;
using Sources.Scripts.PresentationsInterfaces.UI.Buttons;
using Sources.Scripts.PresentationsInterfaces.UI.Images;
using Sources.Scripts.PresentationsInterfaces.Views.Settings;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Settings
{
    public class VolumeView : PresentableView<VolumePresenter>, IVolumeView
    {
        [SerializeField] private ButtonView _volumeButton;
        [SerializeField] private ImageView _imageView;
        [SerializeField] private Sprite _volumeOnSprite;
        [SerializeField] private Sprite _volumeOffSprite;

        public IButtonView VolumeButton => _volumeButton;
        public IImageView ImageView => _imageView;
        public Sprite VolumeOnSprite => _volumeOnSprite;
        public Sprite VolumeOffSprite => _volumeOffSprite;
    }
}