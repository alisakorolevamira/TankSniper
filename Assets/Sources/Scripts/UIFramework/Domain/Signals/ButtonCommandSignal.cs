using System.Collections.Generic;
using Sources.Scripts.UIFramework.Domain.Commands;

namespace Sources.Scripts.UIFramework.Domain.Signals
{
    public struct ButtonCommandSignal
    {
        public ButtonCommandSignal(IEnumerable<ButtonCommandId> buttonCommandIds)
        {
            ButtonCommandIds = buttonCommandIds;
        }

        public IEnumerable<ButtonCommandId> ButtonCommandIds { get; }
    }
}