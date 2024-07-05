using System.Collections.Generic;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Images;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.MainMenu
{
    public interface IMainMenuView
    {
        IImageView CurrentLocation { get; }
        IImageView NextLocation { get; }
        IReadOnlyList<GameObject> FirstGrid { get; }
        IReadOnlyList<GameObject> SecondGrid { get; }
        IReadOnlyList<GameObject> ThirdGrid { get; }
    }
}