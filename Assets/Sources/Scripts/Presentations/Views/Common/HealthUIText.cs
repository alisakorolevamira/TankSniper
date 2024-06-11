using System.Collections.Generic;
using Sources.Scripts.Controllers.Presenters.Common;
using Sources.Scripts.PresentationsInterfaces.UI.Texts;
using Sources.Scripts.PresentationsInterfaces.Views.Common;
using Sources.Scripts.UIFramework.Presentations.Texts;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Common
{
    public class HealthUIText : PresentableView<HealthUITextPresenter>, IHealthUIText
    {
        [SerializeField] private UIText _damageText;

        public IUIText DamageText => _damageText;
    }
}