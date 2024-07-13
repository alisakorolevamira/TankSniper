using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;
using Sources.Scripts.Presentations.Views.Stickman;
using Sources.Scripts.UIFramework.Domain.Commands;

namespace Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Shop.Handlers
{
    public interface IShopCommandHandler
    {
        void Handle(ShopCommandId shopCommandId, SkinType skinType, StickmanType stickmanType);
    }
}