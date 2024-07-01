using System;
using Sources.Scripts.Controllers.Presenters.Shops;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.Domain.Models.Shops;
using Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices;
using Sources.Scripts.PresentationsInterfaces.Views.Shops;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Shops
{
    public class ShopPresenterFactory
    {
        private readonly IUpgradeService _upgradeService;

        public ShopPresenterFactory(IUpgradeService upgradeService)
        {
            _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));
        }
        
        public ShopPresenter Create(IShopView view, Upgrader upgrader, PlayerShop shop)
        {
            return new ShopPresenter(view, _upgradeService, upgrader, shop);
        }
    }
}