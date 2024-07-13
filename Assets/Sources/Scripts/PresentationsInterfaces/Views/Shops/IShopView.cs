using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Shops;

namespace Sources.Scripts.PresentationsInterfaces.Views.Shops
{
    public interface IShopView
    {
        IReadOnlyList<IShopTankButtonView> TankButtons { get; }
        IReadOnlyList<IShopStickmanButtonView> StickmanButtons { get; }
        IReadOnlyList<ShopPatternButtonView> PatternButtons { get; }
        IReadOnlyList<ShopDecalButtonView> DecalButtons { get; }
    }
}