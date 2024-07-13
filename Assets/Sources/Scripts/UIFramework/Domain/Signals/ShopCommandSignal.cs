using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;
using Sources.Scripts.Presentations.Views.Stickman;
using Sources.Scripts.UIFramework.Domain.Commands;

namespace Sources.Scripts.UIFramework.Domain.Signals
{
    public struct ShopCommandSignal
    {
        public ShopCommandSignal(IEnumerable<ShopCommandId> shopCommandIds, SkinType skinType, StickmanType stickmanType)
        {
            ShopCommandIds = shopCommandIds;
            SkinType = skinType;
            StickmanType = stickmanType;
        }

        public IEnumerable<ShopCommandId> ShopCommandIds { get; }
        public SkinType SkinType { get; }
        public StickmanType StickmanType { get; }
    }
}