using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Shop;

namespace Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface IShopPatternButtonDtoMapper
    {
        ShopPatternButtonDto MapModelToDto(ShopPatternButton button);
        ShopPatternButton MapDtoToModel(ShopPatternButtonDto shopPatternButtonDto);
    }
}