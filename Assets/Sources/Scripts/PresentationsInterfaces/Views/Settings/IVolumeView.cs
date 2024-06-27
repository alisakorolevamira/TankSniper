﻿using Sources.Scripts.PresentationsInterfaces.UI.Images;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Settings
{
    public interface IVolumeView
    {
        IImageView ImageView { get; }
        public Sprite VolumeOnSprite { get; }
        public Sprite VolumeOffSprite { get; }
    }
}