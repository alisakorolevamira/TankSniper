using System;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Shop;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Shop
{
    public class SetSkinCommand : IShopCommand
    {
        private readonly ISkinChangerService _skinChangerService;
        private readonly ILoadService _loadService;

        public SetSkinCommand(ISkinChangerService skinChangerService, ILoadService loadService)
        {
            _skinChangerService = skinChangerService ?? throw new ArgumentNullException(nameof(skinChangerService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public ShopCommandId Id => ShopCommandId.ChangeSkin;

        public void Handle(SkinType skinType)
        {
            _skinChangerService.ChangeSkin(skinType);
            _loadService.SaveAll();
        }
    }
}