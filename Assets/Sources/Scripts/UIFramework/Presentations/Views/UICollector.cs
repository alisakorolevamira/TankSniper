using System.Collections.Generic;
using Sources.Scripts.Presentations.Views;
using Sources.Scripts.UIFramework.Presentations.AudioSources;
using Sources.Scripts.UIFramework.Presentations.Buttons;
using Sources.Scripts.UIFramework.PresentationsInterfaces.AudioSources;
using UnityEngine;

namespace Sources.Scripts.UIFramework.Presentations.Views
{
    public class UICollector : View
    {
        [SerializeField] private List<UIView> _uiContainers;
        [SerializeField] private List<UIButton> _uiFormButtons;
        [SerializeField] private List<UIAudioSource> _uiAudioSources;
        [SerializeField] private RectTransform _shootZone;
        
        public IReadOnlyList<UIButton> UIFormButtons => _uiFormButtons;
        public IReadOnlyList<UIView> UIContainers => _uiContainers; //сделать интерфейсы как у аудиосорса??
        public IReadOnlyList<IUIAudioSource> UIAudioSources => _uiAudioSources;
        public RectTransform ShootZone => _shootZone;
    }
}