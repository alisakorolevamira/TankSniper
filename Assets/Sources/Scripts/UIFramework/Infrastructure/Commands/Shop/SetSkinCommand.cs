using System;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Shop;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Shop
{
    public class SetSkinCommand : IShopCommand
    {
        private readonly ISkinChangerService _skinChangerService;

        public SetSkinCommand(ISkinChangerService skinChangerService)
        {
            _skinChangerService = skinChangerService ?? throw new ArgumentNullException(nameof(skinChangerService));
        }

        public ShopCommandId Id => ShopCommandId.ChangeSkin;
        
        public void Handle(int index) => 
            _skinChangerService.ChangeSkin(index);
    }
}