using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;

namespace Sources.Scripts.DomainInterfaces.Models.Shop
{
    public interface IShopPatternButton
    {
        bool IsBought { get; }
        MaterialType MaterialType { get; }
    }
}