using Sources.Scripts.Presentations.Views;
using Sources.Scripts.PresentationsInterfaces.UI.Images;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Scripts.Presentations.UI.Images
{
    public class ImageView : View, IImageView
    {
        [SerializeField] private Image _image;
        
        public void SetSprite(Sprite sprite) =>
            _image.sprite = sprite;
    }
}