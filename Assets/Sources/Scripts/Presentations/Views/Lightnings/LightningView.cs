using Sources.Scripts.Presentations.UI.Images;
using Sources.Scripts.PresentationsInterfaces.UI.Images;
using Sources.Scripts.PresentationsInterfaces.Views.Lightnings;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Lightnings
{
    public class LightningView : View, ILightningView
    {
        [SerializeField] private ImageView _icon;

        public IImageView Icon => _icon;
    }
}