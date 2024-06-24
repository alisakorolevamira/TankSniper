using System.Collections.Generic;
using Sources.Scripts.UIFramework.Domain.Commands;

namespace Sources.Scripts.UIFramework.Domain.Signals
{
    public struct FormCommandSignal
    {
        public FormCommandSignal(IEnumerable<FormCommandId> formCommandIds)
        {
            FormCommandIds = formCommandIds;
        }

        public IEnumerable<FormCommandId> FormCommandIds { get; }
    }
}