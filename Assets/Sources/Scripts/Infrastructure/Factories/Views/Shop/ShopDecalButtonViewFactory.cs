using System;
using Sources.Scripts.Controllers.Presenters.Shop;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Shop;
using Sources.Scripts.Presentations.Views.Shop;
using Sources.Scripts.PresentationsInterfaces.Views.Shop;

namespace Sources.Scripts.Infrastructure.Factories.Views.Shop
{
    public class ShopDecalButtonViewFactory
    {
        private readonly ShopDecalButtonPresenterFactory _presenterFactory;

        public ShopDecalButtonViewFactory(ShopDecalButtonPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IShopDecalButtonView Create(ShopDecalButtonView view, PlayerWallet playerWallet)
        {
            ShopDecalButtonPresenter presenter = _presenterFactory.Create(view, playerWallet);
            
            view.Construct(presenter);

            return view;
        }
    }
}