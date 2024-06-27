using System.Collections.Generic;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Shop;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Shop.Handlers;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Shop.Handlers
{
    public class ShopCommandHandler : IShopCommandHandler
    {
        private readonly Dictionary<ShopCommandId, IShopCommand> _commands = new ();
        
        public ShopCommandHandler(
            SetSkinCommand setSkinCommand)
        {
            _commands[setSkinCommand.Id] = setSkinCommand;
        }

        public void Handle(ShopCommandId shopCommandId, int index)
        {
            if(_commands.ContainsKey(shopCommandId) == false)
                throw new KeyNotFoundException(nameof(shopCommandId));
            
            _commands[shopCommandId].Handle(index);
        }
    }
}