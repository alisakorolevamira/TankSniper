using Sources.Scripts.UIFramework.Domain.Commands;

namespace Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Shop
{
    public interface IShopCommand
    {
        ShopCommandId Id { get; }

        void Handle(int index);
    }
}