using System;
using Sources.Scripts.Controllers.Presenters.Shops;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.Domain.Models.Shops;
using Sources.Scripts.Domain.Models.Stickman;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices;
using Sources.Scripts.PresentationsInterfaces.Views.Shops;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Shops
{
    public class ShopPresenterFactory
    {
        private readonly IUpgradeService _upgradeService;
        private readonly IStickmanChangerService _stickmanChangerService;

        public ShopPresenterFactory(IUpgradeService upgradeService, IStickmanChangerService stickmanChangerService)
        {
            _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));
            _stickmanChangerService = stickmanChangerService ??
                                      throw new ArgumentNullException(nameof(stickmanChangerService));
        }
        
        public ShopPresenter Create(IShopView view, Upgrader upgrader, StickmanChanger stickmanChanger, PlayerShop shop)
        {
            return new ShopPresenter(view, _upgradeService, upgrader, stickmanChanger, shop, _stickmanChangerService);
        }
    }
}