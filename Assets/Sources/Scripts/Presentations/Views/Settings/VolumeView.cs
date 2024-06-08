using Sources.Scripts.Controllers.Presenters.Settings;
using Sources.Scripts.PresentationsInterfaces.UI.Buttons;
using Sources.Scripts.PresentationsInterfaces.UI.Images;
using Sources.Scripts.PresentationsInterfaces.Views.Settings;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Settings
{
    public class VolumeView : PresentableView<VolumePresenter>, IVolumeView
    {
        [field: SerializeField] public IButtonView VolumeButton { get; }
        [field: SerializeField] public IImageView ImageView { get; }
        [field: SerializeField] public Sprite VolumeOnSprite { get; }
        [field: SerializeField] public Sprite VolumeOffSprite { get; }
    }
}