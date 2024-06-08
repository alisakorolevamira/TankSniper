using Sources.Scripts.Presentations.Views;
using Sources.Scripts.Presentations.Views.Gameplay;
using Sources.Scripts.Presentations.Views.Settings;
using Sources.Scripts.UIFramework.Presentations.Views;
using UnityEngine;

namespace Sources.Scripts.Presentations.UI.Huds
{
    public class MainMenuHud : View, IHud
    {
        [field: SerializeField] public UICollector UICollector { get; }
        [field: SerializeField] public LevelAvailabilityView LevelAvailabilityView { get; }
        [field: SerializeField] public VolumeView VolumeView { get; }
    }
}