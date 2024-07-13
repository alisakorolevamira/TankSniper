using System;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;
using Sources.Scripts.Presentations.Views.Stickman;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Shop;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Shop
{
    public class SetDefaultMaterialCommand : IShopCommand
    {
        private readonly ISkinChangerService _skinChangerService;
        private readonly ILoadService _loadService;

        public SetDefaultMaterialCommand(ISkinChangerService skinChangerService, ILoadService loadService)
        {
            _skinChangerService = skinChangerService ?? throw new ArgumentNullException(nameof(skinChangerService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public ShopCommandId Id => ShopCommandId.ChangeMaterial;

        public void Handle(SkinType skinType, StickmanType stickmanType)
        {
            _skinChangerService.ChangeMaterial(MaterialType.Default);
            _loadService.SaveAll();
        }
    }
}