using Sources.Scripts.Controllers.Presenters.Weapons;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;
using Sources.Scripts.UIFramework.Presentations.Images;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Images;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Weapons
{
    public class ReloadWeaponView : PresentableView<ReloadWeaponPresenter>, IReloadWeaponView
    {
        [SerializeField] private ImageView _imageView;

        public IImageView ImageView => _imageView;
    }
}