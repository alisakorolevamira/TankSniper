using Sources.Scripts.PresentationsInterfaces.UI.Images;
using Sources.Scripts.PresentationsInterfaces.Views.Gameplay;
using Sources.Scripts.UIFramework.Presentations.Images;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Gameplay
{
    public class LevelView : View, ILevelView
    {
        [SerializeField] private ImageView _imageView;
        
        public IImageView ImageView { get; }
    }
}