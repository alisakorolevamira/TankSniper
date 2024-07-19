using System;
using Sources.Scripts.Controllers.Presenters.Shops;
using Sources.Scripts.Domain.Models.Shops;
using Sources.Scripts.Domain.Models.Stickman;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Shops;
using Sources.Scripts.Presentations.Views.Shops;
using Sources.Scripts.PresentationsInterfaces.Views.Shops;

namespace Sources.Scripts.Infrastructure.Factories.Views.Shops
{
    public class ShopViewFactory
    {
        private readonly ShopPresenterFactory _presenterFactory;

        public ShopViewFactory(ShopPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IShopView Create(ShopView shopView, Upgrader upgrader, StickmanChanger stickmanChanger, PlayerShop shop)
        {
            ShopPresenter presenter = _presenterFactory.Create(shopView, upgrader, stickmanChanger, shop);
            shopView.Construct(presenter);

            return shopView;
        }
    }
}