using System.Collections.Generic;
using Sources.Scripts.Controllers.Presenters.Players;
using Sources.Scripts.Presentations.Views.Bullets;
using Sources.Scripts.Presentations.Views.Lightnings;
using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Lightnings;
using Sources.Scripts.PresentationsInterfaces.Views.Players;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Players
{
    public class AttackerUIView : PresentableView<AttackerUIPresenter>, IAttackerUIView
    {
        [SerializeField] private List<BulletUIView> _bullets;
        [SerializeField] private List<LightningView> _lightnings;

        public IReadOnlyList<IBulletUIView> BulletViews => _bullets;
        public IReadOnlyList<ILightningView> LightningViews => _lightnings;
    }
}