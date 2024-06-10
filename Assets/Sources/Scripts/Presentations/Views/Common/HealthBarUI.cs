using Sources.Scripts.Controllers.Presenters.Common;
using Sources.Scripts.Presentations.UI.Images;
using Sources.Scripts.PresentationsInterfaces.UI.Images;
using Sources.Scripts.PresentationsInterfaces.Views.Common;
using Sources.Scripts.PresentationsInterfaces.Views.Players;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Common
{
    public class HealthBarUI : PresentableView<HealthBarUIPresenter>, IHealthBarUI
    {
        [SerializeField] private ImageView _healthImage;
        
        public IImageView HealthImage => _healthImage;
    }
}