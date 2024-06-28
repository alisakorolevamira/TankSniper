using System.Collections.Generic;

namespace Sources.Scripts.PresentationsInterfaces.Views.Shop
{
    public interface IShopView
    {
        IReadOnlyList<IShopButtonView> Buttons { get; }
    }
}