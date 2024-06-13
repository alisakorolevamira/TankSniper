using System.Collections.Generic;
using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Lightnings;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Players
{
    public interface IAttackerUIView
    {
        IReadOnlyList<IBulletUIView> BulletViews { get; }
        IReadOnlyList<ILightningView> LightningViews { get; }
    }
}