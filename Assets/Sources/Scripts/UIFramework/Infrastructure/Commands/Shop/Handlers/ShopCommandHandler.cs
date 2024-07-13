using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;
using Sources.Scripts.Presentations.Views.Stickman;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Shop;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Shop.Handlers;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Shop.Handlers
{
    public class ShopCommandHandler : IShopCommandHandler
    {
        private readonly Dictionary<ShopCommandId, IShopCommand> _commands = new ();
        
        public ShopCommandHandler(
            SetSkinCommand setSkinCommand,
            SetDefaultMaterialCommand setDefaultMaterialCommand,
            RemoveDecalCommand removeDecalCommand,
            SetStickmanCommand setStickmanCommand)
        {
            _commands[setSkinCommand.Id] = setSkinCommand;
            _commands[setDefaultMaterialCommand.Id] = setDefaultMaterialCommand;
            _commands[removeDecalCommand.Id] = removeDecalCommand;
            _commands[setStickmanCommand.Id] = setStickmanCommand;
        }

        public void Handle(ShopCommandId shopCommandId, SkinType skinType, StickmanType stickmanType)
        {
            if (_commands.ContainsKey(shopCommandId) == false)
                throw new KeyNotFoundException(nameof(shopCommandId));
            
            _commands[shopCommandId].Handle(skinType, stickmanType);
        }
    }
}