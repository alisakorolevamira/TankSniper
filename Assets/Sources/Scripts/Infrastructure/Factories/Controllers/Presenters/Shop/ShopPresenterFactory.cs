using System;
using JetBrains.Annotations;
using Sources.Scripts.Controllers.Presenters.Shop;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices;
using Sources.Scripts.PresentationsInterfaces.Views.Shop;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Shop
{
    public class ShopPresenterFactory
    {
        private readonly IUpgradeService _upgradeService;

        public ShopPresenterFactory(IUpgradeService upgradeService)
        {
            _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));
        }
        
        public ShopPresenter Create(IShopView view, Upgrader upgrader)
        {
            return new ShopPresenter(view, _upgradeService, upgrader);
        }
    }
}