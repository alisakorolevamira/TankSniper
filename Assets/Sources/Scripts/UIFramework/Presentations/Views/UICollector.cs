using System.Collections.Generic;
using Sources.Scripts.Presentations.Views;
using Sources.Scripts.UIFramework.Presentations.Buttons;
using UnityEngine;

namespace Sources.Scripts.UIFramework.Presentations.Views
{
    public class UICollector : View
    {
        [SerializeField] private List<UIView> _uiContainers;
        [SerializeField] private List<UIButton> _uiFormButtons;
        
        public IReadOnlyList<UIButton> UIFormButtons => _uiFormButtons;
        public IReadOnlyList<UIView> UIContainers => _uiContainers;
    }
}