﻿using Sources.Scripts.Presentations.Views;
using Sources.Scripts.PresentationsInterfaces.UI.Buttons;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Sources.Scripts.Presentations.UI.Buttons
{
    public class ButtonView : View, IButtonView
    {
        [SerializeField] private Button _button;
        
        public void AddClickListener(UnityAction onClick) =>
            _button.onClick.AddListener(onClick);

        public void RemoveClickListener(UnityAction onClick) =>
            _button.onClick.RemoveListener(onClick);

        public void Enable() =>
            _button.enabled = true;

        public void Disable() =>
            _button.enabled = false;
    }
}