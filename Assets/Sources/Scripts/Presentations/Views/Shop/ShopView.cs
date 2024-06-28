using System.Collections.Generic;
using Sources.Scripts.Controllers.Presenters.Shop;
using Sources.Scripts.PresentationsInterfaces.Views.Shop;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Shop
{
    public class ShopView : PresentableView<ShopPresenter>, IShopView
    {
        [SerializeField] private List<ShopButtonView> _buttons;

        public IReadOnlyList<IShopButtonView> Buttons => _buttons;
    }
}