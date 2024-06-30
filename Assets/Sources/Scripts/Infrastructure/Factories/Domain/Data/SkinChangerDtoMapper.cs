using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Scripts.Infrastructure.Factories.Domain.Data
{
    public class SkinChangerDtoMapper : ISkinChangerDtoMapper
    {
        public SkinChangerDto MapModelToDto(SkinChanger skinChanger)
        {
            return new SkinChangerDto()
            {
                CurrentMaterialType = skinChanger.CurrentMaterial,
                CurrentDecalType = skinChanger.CurrentDecal,
                CurrentSkinType = skinChanger.CurrentSkin,
                Id = skinChanger.Id,
            };
        }

        public SkinChanger MapDtoToModel(SkinChangerDto skinChangerDto) => 
            new(
                skinChangerDto.CurrentSkinType,
                skinChangerDto.CurrentMaterialType,
                skinChangerDto.CurrentDecalType,
                skinChangerDto.Id);
    }
}