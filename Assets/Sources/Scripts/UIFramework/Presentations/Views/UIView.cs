using System.Collections.Generic;
using Sources.Scripts.Presentations.Views;
using Sources.Scripts.UIFramework.Controllers.Forms;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.Presentations.CommonTypes;
using Sources.Scripts.UIFramework.Presentations.Views.Types;
using Sources.Scripts.UIFramework.PresentationsInterfaces;
using UnityEngine;

namespace Sources.Scripts.UIFramework.Presentations.Views
{
    public class UIView : PresentableView<UIViewPresenter>, IUIView
    {
        [SerializeField] private List<FormId> _onEnableEnabledForms;
        [SerializeField] private List<FormId> _onEnableDisabledForms;
        [SerializeField] private List<FormId> _onDisableEnabledForms;
        [SerializeField] private List<FormId> _onDisableDisabledForms;
        [SerializeField] private List<FormCommandId> _enabledFormCommands;
        [SerializeField] private List<FormCommandId> _disabledFormCommands;
        
        [field: SerializeField] public Enable EnabledGameObject { get; }
        [field: SerializeField] public Enable EnabledCanvasGroup { get; }
        [field: SerializeField] public FormId FormId { get; }
        
        public IReadOnlyList<FormId> OnEnableEnabledForms => _onEnableEnabledForms;
        public IReadOnlyList<FormId> OnEnableDisabledForms => _onEnableDisabledForms;
        public IReadOnlyList<FormId> OnDisableEnabledForms => _onDisableEnabledForms;
        public IReadOnlyList<FormId> OnDisableDisabledForms => _onDisableDisabledForms;

        public IReadOnlyList<FormCommandId> EnabledFormCommands => _enabledFormCommands;
        public IReadOnlyList<FormCommandId> DisabledFormCommands => _disabledFormCommands;
        
        public bool IsActive => gameObject.activeSelf;
    }
}