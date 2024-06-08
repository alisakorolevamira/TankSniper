﻿using Sources.Scripts.PresentationsInterfaces.Views;
using UnityEngine.Events;

namespace Sources.Scripts.PresentationsInterfaces.UI.Buttons
{
    public interface IButtonView : IView
    {
        void AddClickListener(UnityAction onClick);
        void RemoveClickListener(UnityAction onClick);
        void Enable();
        void Disable();
    }
}