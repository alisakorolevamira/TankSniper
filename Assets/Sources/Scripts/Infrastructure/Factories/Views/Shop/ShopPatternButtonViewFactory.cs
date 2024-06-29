using System;
using JetBrains.Annotations;
using Sources.Scripts.Controllers.Presenters.Shop;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Shop;
using Sources.Scripts.Presentations.Views.Shop;
using Sources.Scripts.PresentationsInterfaces.Views.Shop;

namespace Sources.Scripts.Infrastructure.Factories.Views.Shop
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