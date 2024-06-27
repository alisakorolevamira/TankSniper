using Sources.Scripts.UIFramework.Domain.Commands;

namespace Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Shop.Handlers
{
    public interface IShopCommandHandler
    {
        void Handle(ShopCommandId shopCommandId, int index);
    }
}