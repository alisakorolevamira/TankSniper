using System.Collections.Generic;
using Doozy.Runtime.UIManager.Components;
using Sources.Scripts.Presentations.Views;
using Sources.Scripts.UIFramework.Presentations.AudioSources;
using Sources.Scripts.UIFramework.PresentationsInterfaces.AudioSources;
using UnityEngine;

namespace Sources.Scripts.UIFramework.Presentations.Views
{
    public class UICollector : View
    {
        [Header("Containers")]
        [SerializeField] private List<UIView> _uiContainers;
        
        [Header("Audio")]
        [SerializeField] private List<UIAudioSource> _uiAudioSources;
        
        public IReadOnlyList<UIView> UIContainers => _uiContainers;
        public IReadOnlyList<IUIAudioSource> UIAudioSources => _uiAudioSources;
    }
}