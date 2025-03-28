﻿using Sources.Scripts.PresentationsInterfaces.Views.Lightnings;
using Sources.Scripts.UIFramework.Presentations.Images;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Images;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Lightnings
{
    public class LightningView : View, ILightningView
    {
        [SerializeField] private ImageView _icon;
        [SerializeField] private Sprite _empty;
        [SerializeField] private Sprite _filled;

        public IImageView Icon => _icon;
        public bool IsShowed { get; private set; } = false;
        
        public void Awake() => 
            Hide();

        public void Show()
        {
            _icon.SetSprite(_filled);
            IsShowed = true;
        }

        public void Hide()
        {
            _icon.SetSprite(_empty);
            IsShowed = false;
        }
    }
}