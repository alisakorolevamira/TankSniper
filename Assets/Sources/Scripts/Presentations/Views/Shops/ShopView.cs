using System.Collections.Generic;
using Sources.Scripts.Controllers.Presenters.Shops;
using Sources.Scripts.PresentationsInterfaces.Views.Shops;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Shops
{
    public class ShopView : PresentableView<ShopPresenter>, IShopView
    {
        [SerializeField] private List<ShopTankButtonView> _tankButtons;
        [SerializeField] private List<ShopPatternButtonView> _patternButtons;
        [SerializeField] private List<ShopDecalButtonView> _decalButtons;

        public IReadOnlyList<IShopTankButtonView> TankButtons => _tankButtons;
        public IReadOnlyList<ShopPatternButtonView> PatternButtons => _patternButtons;
        public IReadOnlyList<ShopDecalButtonView> DecalButtons => _decalButtons;
    }
}