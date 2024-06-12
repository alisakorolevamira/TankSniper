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
    public class PlayerAttackerView : PresentableView<PlayerAttackerPresenter>, IPlayerAttackerView
    {
        [SerializeField] private List<BulletView> _bullets;
        [SerializeField] private List<LightningView> _lightnings;
        [SerializeField] private ParticleSystem _shootEffect;

        public IReadOnlyList<IBulletView> BulletViews => _bullets;
        public IReadOnlyList<ILightningView> LightningViews => _lightnings;
        public ParticleSystem ShootEffect { get; }
    }
}