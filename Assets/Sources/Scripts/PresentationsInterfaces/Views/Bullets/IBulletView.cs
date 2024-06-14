﻿using Sources.Scripts.PresentationsInterfaces.Views.Constructions;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Bullets
{
    public interface IBulletView : IConstruct<IWeaponView>, IView
    {
        Rigidbody Rigidbody { get; }
    }
}