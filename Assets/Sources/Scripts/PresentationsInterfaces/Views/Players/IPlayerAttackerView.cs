using System.Collections.Generic;
using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Lightnings;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Buttons;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Players
{
    public interface IPlayerAttackerView
    {
        ParticleSystem ShootEffect { get; }
        IReadOnlyList<IBulletView> BulletViews { get; }
        IReadOnlyList<ILightningView> LightningViews { get; }
    }
}