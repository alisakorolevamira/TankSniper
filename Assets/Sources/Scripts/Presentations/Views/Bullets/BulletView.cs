using Sources.Scripts.Presentations.UI.Images;
using Sources.Scripts.PresentationsInterfaces.UI.Images;
using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.UIFramework.Presentations.Views;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Bullets
{
    public class BulletView : View, IBulletView
    {
        [SerializeField] private ImageView _icon;

        public IImageView Icon => _icon;
        public bool IsShowed { get; private set; } = true;

        public void Show()
        {
            _icon.Show();
            IsShowed = true;
        }

        public void Hide()
        {
            _icon.Hide();
            IsShowed = false;
        }
    }
}