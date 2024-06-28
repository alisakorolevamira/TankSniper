using System;
using Sources.Scripts.Controllers.Presenters.Shop;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Shop;
using Sources.Scripts.Presentations.Views.Shop;
using Sources.Scripts.PresentationsInterfaces.Views.Shop;

namespace Sources.Scripts.Infrastructure.Factories.Views.Shop
{
    public class ShopViewFactory
    {
        private readonly ShopPresenterFactory _presenterFactory;

        public ShopViewFactory(ShopPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IShopView Create(ShopView shopView, Upgrader upgrader)
        {
            ShopPresenter presenter = _presenterFactory.Create(shopView, upgrader);
            shopView.Construct(presenter);

            return shopView;
        }
    }
}