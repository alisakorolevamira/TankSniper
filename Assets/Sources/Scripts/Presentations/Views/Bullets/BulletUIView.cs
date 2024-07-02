using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.UIFramework.Presentations.Images;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Images;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Bullets
{
    public class BulletUIView : View, IBulletUIView
    {
        [SerializeField] private ImageView _icon;

        public IImageView Icon => _icon;
        public bool IsShowed { get; private set; } = true;

        public void Awake() => 
            Show();

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