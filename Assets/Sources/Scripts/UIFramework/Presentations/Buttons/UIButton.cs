using System.Collections.Generic;
using Sources.Scripts.UIFramework.Controllers.Buttons;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.Presentations.Buttons.Types;
using Sources.Scripts.UIFramework.Presentations.Views.Types;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Buttons;
using UnityEngine;

namespace Sources.Scripts.UIFramework.Presentations.Buttons
{
    public class UIButton : PresentableUIButton<UIButtonPresenter>, IUIButton
    {
        [SerializeField] private FormId _formId;
        [SerializeField] private UseButtonType _useButtonType;
        [SerializeField] private float _delay;
        [SerializeField] private List<ButtonCommandId> _onClickCommandId;
        [SerializeField] private List<ButtonCommandId> _enableCommandId;
        [SerializeField] private List<ButtonCommandId> _disableCommandId;

        public float Delay => _delay;
        public List<ButtonCommandId> OnClickCommandId => _onClickCommandId;
        public List<ButtonCommandId> EnableCommandId => _enableCommandId;
        public List<ButtonCommandId> DisableCommandId => _disableCommandId;
        public UseButtonType UseButtonType => _useButtonType;
        public FormId FormId => _formId;
    }
}