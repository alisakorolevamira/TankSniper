using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Shop;

namespace Sources.Scripts.PresentationsInterfaces.Views.Shop
{
    public interface IShopView
    {
        IReadOnlyList<IShopTankButtonView> TankButtons { get; }
        IReadOnlyList<ShopPatternButtonView> PatternButtons { get; }
        IReadOnlyList<ShopDecalButtonView> DecalButtons { get; }
    }
}