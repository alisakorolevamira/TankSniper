using System;
using Sources.Scripts.Controllers.Presenters.Shops;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Shops;
using Sources.Scripts.Presentations.Views.Shops;
using Sources.Scripts.PresentationsInterfaces.Views.Shops;

namespace Sources.Scripts.Infrastructure.Factories.Views.Shops
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