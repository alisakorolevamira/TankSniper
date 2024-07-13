using System;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;
using Sources.Scripts.Presentations.Views.Stickman;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Shop;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Shop
{
    public class SetStickmanCommand : IShopCommand
    {
        private readonly IStickmanChangerService _stickmanChangerService;
        private readonly ILoadService _loadService;

        public SetStickmanCommand(IStickmanChangerService stickmanChangerService, ILoadService loadService)
        {
            _stickmanChangerService = stickmanChangerService ??
                                      throw new ArgumentNullException(nameof(stickmanChangerService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public ShopCommandId Id => ShopCommandId.ChangeStickman;

        public void Handle(SkinType skinType, StickmanType stickmanType)
        {
            _stickmanChangerService.ChangeStickman(stickmanType);
            _loadService.SaveAll();
        }
    }
}