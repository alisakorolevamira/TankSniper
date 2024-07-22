using System;
using Sources.Scripts.Controllers.Presenters.Shops;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.InfrastructureInterfaces.Services.Yandex;
using Sources.Scripts.PresentationsInterfaces.Views.Shops;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Shops
{
    public class ShopPatternButtonPresenterFactory
    {
        private readonly IStickyAdService _stickyAdService;
        private readonly ISkinChangerService _skinChangerService;
        private readonly ILoadService _loadService;

        public ShopPatternButtonPresenterFactory(
            IStickyAdService stickyAdService,
            ISkinChangerService skinChangerService,
            ILoadService loadService)
        {
            _stickyAdService = stickyAdService ?? throw new ArgumentNullException(nameof(stickyAdService));
            _skinChangerService = skinChangerService ?? throw new ArgumentNullException(nameof(skinChangerService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }
        
        public ShopPatternButtonPresenter Create(IShopPatternButtonView view, PlayerWallet playerWallet) => 
            new (view, _stickyAdService, _skinChangerService, _loadService, playerWallet);
    }
}