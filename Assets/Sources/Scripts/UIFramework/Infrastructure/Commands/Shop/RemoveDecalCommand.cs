using System;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.Presentations.Views.Players.Skins.DecalsType;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Shop;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Shop
{
    public class RemoveDecalCommand : IShopCommand
    {
        private readonly ISkinChangerService _skinChangerService;

        public RemoveDecalCommand(ISkinChangerService skinChangerService)
        {
            _skinChangerService = skinChangerService ?? throw new ArgumentNullException(nameof(skinChangerService));
        }

        public ShopCommandId Id => ShopCommandId.RemoveDecal;

        public void Handle(SkinType skinType) =>
            _skinChangerService.ChangeDecal(DecalType.Default);
    }
}