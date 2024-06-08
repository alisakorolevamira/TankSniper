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
        [field: SerializeField] public FormId FormId { get; }
        [field: SerializeField] public UseButtonType UseButtonType { get; }
        [field: SerializeField] public float Delay { get; }
        [field: SerializeField] public List<ButtonCommandId> OnClickCommandId { get; }
        [field: SerializeField] public List<ButtonCommandId> EnableCommandId { get; }
        [field: SerializeField] public List<ButtonCommandId> DisableCommandId { get; }
    }
}