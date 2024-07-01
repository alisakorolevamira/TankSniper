using System;
using Sources.Scripts.Controllers.Presenters.Shops;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Shop;
using Sources.Scripts.Presentations.Views.Shops;
using Sources.Scripts.PresentationsInterfaces.Views.Shops;

namespace Sources.Scripts.Infrastructure.Factories.Views.Shops
{
    public class ShopPatternButtonViewFactory
    {
        private readonly ShopPatternButtonPresenterFactory _presenterFactory;

        public ShopPatternButtonViewFactory(ShopPatternButtonPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IShopPatternButtonView Create(ShopPatternButtonView view, PlayerWallet playerWallet)
        {
            ShopPatternButtonPresenter presenter = _presenterFactory.Create(view, playerWallet);
            
            view.Construct(presenter);

            return view;
        }
    }
}