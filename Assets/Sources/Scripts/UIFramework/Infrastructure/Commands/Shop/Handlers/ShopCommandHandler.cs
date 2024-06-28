using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;
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
            SetMaterialCommand setMaterialCommand)
        {
            _commands[setSkinCommand.Id] = setSkinCommand;
            _commands[setMaterialCommand.Id] = setMaterialCommand;
        }

        public void Handle(ShopCommandId shopCommandId, SkinType skinType, MaterialType materialType)
        {
            if (_commands.ContainsKey(shopCommandId) == false)
                throw new KeyNotFoundException(nameof(shopCommandId));
            
            if (shopCommandId == ShopCommandId.ChangeSkin)
                _commands[shopCommandId].Handle(skinType);
            
            else if (shopCommandId == ShopCommandId.ChangeMaterial)
                _commands[shopCommandId].Handle(materialType);
        }
    }
}