using System.Collections.Generic;
using Sources.Scripts.UIFramework.Domain.Commands;

namespace Sources.Scripts.UIFramework.Domain.Signals
{
    public struct ShopCommandSignal
    {
        public ShopCommandSignal(IEnumerable<ShopCommandId> shopCommandIds, int index)
        {
            ShopCommandIds = shopCommandIds;
            Index = index;
        }

        public IEnumerable<ShopCommandId> ShopCommandIds { get; }
        public int Index { get; }
    }
}