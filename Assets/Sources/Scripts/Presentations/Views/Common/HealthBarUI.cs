using Sources.Scripts.Controllers.Presenters.Common;
using Sources.Scripts.PresentationsInterfaces.Views.Common;
using Sources.Scripts.PresentationsInterfaces.Views.Players;
using Sources.Scripts.UIFramework.Presentations.Images;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Images;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Common
{
    public class HealthBarUI : PresentableView<HealthBarUIPresenter>, IHealthBarUI
    {
        [SerializeField] private ImageView _healthImage;
        
        public IImageView HealthImage => _healthImage;
    }
}