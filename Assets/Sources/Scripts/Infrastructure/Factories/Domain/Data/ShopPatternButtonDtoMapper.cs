using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Shop;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Scripts.Infrastructure.Factories.Domain.Data
{
    public class ShopPatternButtonDtoMapper : IShopPatternButtonDtoMapper
    {
        public ShopPatternButtonDto MapModelToDto(ShopPatternButton button)
        {
            return new ShopPatternButtonDto()
            {
                IsBought = button.IsBought,
                MaterialType = button.MaterialType,
                Id = button.Id
            };
        }

        public ShopPatternButton MapDtoToModel(ShopPatternButtonDto buttonDto) => 
            new(buttonDto.Id, buttonDto.IsBought, buttonDto.MaterialType);
    }
}