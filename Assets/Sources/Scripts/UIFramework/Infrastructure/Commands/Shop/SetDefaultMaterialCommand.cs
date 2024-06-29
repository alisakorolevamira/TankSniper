using System;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Shop;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Shop
{
    public class SetDefaultMaterialCommand : IShopCommand
    {
        private readonly ISkinChangerService _skinChangerService;

        public SetDefaultMaterialCommand(ISkinChangerService skinChangerService)
        {
            _skinChangerService = skinChangerService ?? throw new ArgumentNullException(nameof(skinChangerService));
        }

        public ShopCommandId Id => ShopCommandId.ChangeMaterial;

        public void Handle(SkinType skinType) =>
            _skinChangerService.ChangeMaterial(MaterialType.Default);
    }
}