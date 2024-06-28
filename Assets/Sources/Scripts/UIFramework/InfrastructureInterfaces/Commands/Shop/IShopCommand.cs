using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;
using Sources.Scripts.UIFramework.Domain.Commands;

namespace Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Shop
{
    public interface IShopCommand
    {
        ShopCommandId Id { get; }

        void Handle(SkinType skinType);
        void Handle(MaterialType materialType);
    }
}