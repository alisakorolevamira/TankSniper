﻿using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Weapons;
using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Lightnings;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Images;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Players
{
    public interface IAttackerUIView
    {
        IReadOnlyList<IBulletUIView> BulletViews { get; }
        IReadOnlyList<ILightningView> LightningViews { get; }
        IImageView LightningAim { get; }
        WeaponView WeaponView { get; }
    }
}