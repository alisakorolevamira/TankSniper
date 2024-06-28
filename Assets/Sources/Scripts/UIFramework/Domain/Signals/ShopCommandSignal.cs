﻿using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;
using Sources.Scripts.UIFramework.Domain.Commands;

namespace Sources.Scripts.UIFramework.Domain.Signals
{
    public struct ShopCommandSignal
    {
        public ShopCommandSignal(IEnumerable<ShopCommandId> shopCommandIds, SkinType skinType, MaterialType materialType)
        {
            ShopCommandIds = shopCommandIds;
            SkinType = skinType;
            MaterialType = materialType;
        }

        public IEnumerable<ShopCommandId> ShopCommandIds { get; }
        public SkinType SkinType { get; }
        public MaterialType MaterialType { get; }
    }
}