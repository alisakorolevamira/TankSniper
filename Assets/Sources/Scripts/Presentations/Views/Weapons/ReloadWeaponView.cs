using Sources.Scripts.Controllers.Presenters.Weapons;
using Sources.Scripts.Presentations.UI.Images;
using Sources.Scripts.PresentationsInterfaces.UI.Images;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Weapons
{
    public class ReloadWeaponView : PresentableView<ReloadWeaponPresenter>, IReloadWeaponView
    {
        [SerializeField] private ImageView _imageView;

        public IImageView ImageView => _imageView;
    }
}